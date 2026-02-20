using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.TrainingModule.Application.Services.TrainingSession;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingSession;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.TrainingModule.Application.Tests.Services.TrainingSession
{
    public class UpdateTrainingSessionCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITrainingSessionRepository> _repositoryMock;
        private readonly Mock<ILogger<TrainingSessionService>> _loggerMock;
        private readonly TrainingSessionService _service;
        public UpdateTrainingSessionCommandTests()
        {
            _repositoryMock = new Mock<ITrainingSessionRepository>();
            _loggerMock = new Mock<ILogger<TrainingSessionService>>();
            _service = new TrainingSessionService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TrainingSessionDto>("tr");
            var fakeGetResponse = new RepoResponse<TrainingSessionDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<TrainingSessionDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TrainingSessionDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TrainingSessionDto>("tr");
            var fakeGetResponse = new RepoResponse<TrainingSessionDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TrainingSessionDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}