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
    public class UpdateInterviewFeedbackAnswerCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewFeedbackAnswerRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewFeedbackAnswerService>> _loggerMock;
        private readonly InterviewFeedbackAnswerService _service;
        public UpdateInterviewFeedbackAnswerCommandTests()
        {
            _repositoryMock = new Mock<IInterviewFeedbackAnswerRepository>();
            _loggerMock = new Mock<ILogger<InterviewFeedbackAnswerService>>();
            _service = new InterviewFeedbackAnswerService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackAnswerDto>("tr");
            var fakeGetResponse = new RepoResponse<InterviewFeedbackAnswerDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<InterviewFeedbackAnswerDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<InterviewFeedbackAnswerDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewFeedbackAnswerDto>("tr");
            var fakeGetResponse = new RepoResponse<InterviewFeedbackAnswerDto>
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
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<InterviewFeedbackAnswerDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}