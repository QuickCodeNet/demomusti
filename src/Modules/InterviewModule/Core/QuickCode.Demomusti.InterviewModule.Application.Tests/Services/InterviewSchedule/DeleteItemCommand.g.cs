using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.InterviewModule.Application.Services.InterviewSchedule;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewSchedule;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.InterviewModule.Application.Tests.Services.InterviewSchedule
{
    public class InterviewScheduleServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewScheduleRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewScheduleService>> _loggerMock;
        private readonly InterviewScheduleService _service;
        public InterviewScheduleServiceDeleteTests()
        {
            _repositoryMock = new Mock<IInterviewScheduleRepository>();
            _loggerMock = new Mock<ILogger<InterviewScheduleService>>();
            _service = new InterviewScheduleService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewScheduleDto>("tr");
            var fakeGetResponse = new RepoResponse<InterviewScheduleDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<InterviewScheduleDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<InterviewScheduleDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<InterviewScheduleDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<InterviewScheduleDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<InterviewScheduleDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}