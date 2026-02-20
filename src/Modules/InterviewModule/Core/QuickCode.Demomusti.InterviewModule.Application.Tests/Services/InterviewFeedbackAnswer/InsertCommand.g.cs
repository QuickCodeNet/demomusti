using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.InterviewModule.Application.Services.InterviewFeedbackAnswer;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewFeedbackAnswer;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.InterviewModule.Application.Tests.Services.InterviewFeedbackAnswer
{
    public class InsertInterviewFeedbackAnswerCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewFeedbackAnswerRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewFeedbackAnswerService>> _loggerMock;
        private readonly InterviewFeedbackAnswerService _service;
        public InsertInterviewFeedbackAnswerCommandTests()
        {
            _repositoryMock = new Mock<IInterviewFeedbackAnswerRepository>();
            _loggerMock = new Mock<ILogger<InterviewFeedbackAnswerService>>();
            _service = new InterviewFeedbackAnswerService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackAnswerDto>("tr");
            var fakeResponse = new RepoResponse<InterviewFeedbackAnswerDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewFeedbackAnswerDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<InterviewFeedbackAnswerDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackAnswerDto>("tr");
            var fakeResponse = new RepoResponse<InterviewFeedbackAnswerDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewFeedbackAnswerDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}