using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.InterviewModule.Application.Services.Interview;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.Interview;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.InterviewModule.Application.Tests.Services.Interview
{
    public class InsertInterviewCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInterviewRepository> _repositoryMock;
        private readonly Mock<ILogger<InterviewService>> _loggerMock;
        private readonly InterviewService _service;
        public InsertInterviewCommandTests()
        {
            _repositoryMock = new Mock<IInterviewRepository>();
            _loggerMock = new Mock<ILogger<InterviewService>>();
            _service = new InterviewService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewDto>("tr");
            var fakeResponse = new RepoResponse<InterviewDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<InterviewDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InterviewDto>("tr");
            var fakeResponse = new RepoResponse<InterviewDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InterviewDto>())).ReturnsAsync(fakeResponse);
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