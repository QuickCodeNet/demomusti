using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Services.CandidateSource;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.CandidateSource;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Tests.Services.CandidateSource
{
    public class InsertCandidateSourceCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICandidateSourceRepository> _repositoryMock;
        private readonly Mock<ILogger<CandidateSourceService>> _loggerMock;
        private readonly CandidateSourceService _service;
        public InsertCandidateSourceCommandTests()
        {
            _repositoryMock = new Mock<ICandidateSourceRepository>();
            _loggerMock = new Mock<ILogger<CandidateSourceService>>();
            _service = new CandidateSourceService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CandidateSourceDto>("tr");
            var fakeResponse = new RepoResponse<CandidateSourceDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CandidateSourceDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CandidateSourceDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CandidateSourceDto>("tr");
            var fakeResponse = new RepoResponse<CandidateSourceDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CandidateSourceDto>())).ReturnsAsync(fakeResponse);
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