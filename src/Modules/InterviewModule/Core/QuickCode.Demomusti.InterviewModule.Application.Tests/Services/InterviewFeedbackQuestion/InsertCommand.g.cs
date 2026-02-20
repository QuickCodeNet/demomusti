using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.InterviewModule.Application.Services.InterviewFeedbackQuestion;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewFeedbackQuestion;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.InterviewModule.Application.Tests.Services.InterviewFeedbackQuestion
{
    public class InsertInterviewFeedbackQuestionCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewFeedbackQuestionRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewFeedbackQuestionService>> _loggerMock;
        private readonly InterviewFeedbackQuestionService _service;
        public InsertInterviewFeedbackQuestionCommandTests()
        {
            _repositoryMock = new Mock<IInterviewFeedbackQuestionRepository>();
            _loggerMock = new Mock<ILogger<InterviewFeedbackQuestionService>>();
            _service = new InterviewFeedbackQuestionService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackQuestionDto>("tr");
            var fakeResponse = new RepoResponse<InterviewFeedbackQuestionDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewFeedbackQuestionDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<InterviewFeedbackQuestionDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackQuestionDto>("tr");
            var fakeResponse = new RepoResponse<InterviewFeedbackQuestionDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewFeedbackQuestionDto>())).ReturnsAsync(fakeResponse);
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