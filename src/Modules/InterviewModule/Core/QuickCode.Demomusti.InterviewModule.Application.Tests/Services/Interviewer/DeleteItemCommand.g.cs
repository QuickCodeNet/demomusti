using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.InterviewModule.Application.Services.Interviewer;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.Interviewer;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.InterviewModule.Application.Tests.Services.Interviewer
{
    public class InterviewerServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewerRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewerService>> _loggerMock;
        private readonly InterviewerService _service;
        public InterviewerServiceDeleteTests()
        {
            _repositoryMock = new Mock<IInterviewerRepository>();
            _loggerMock = new Mock<ILogger<InterviewerService>>();
            _service = new InterviewerService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewerDto>("tr");
            var fakeGetResponse = new RepoResponse<InterviewerDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<InterviewerDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<InterviewerDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<InterviewerDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<InterviewerDto>
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
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<InterviewerDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}