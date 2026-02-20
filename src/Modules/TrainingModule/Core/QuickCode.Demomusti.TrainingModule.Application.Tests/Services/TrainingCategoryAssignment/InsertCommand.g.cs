using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategoryAssignment;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategoryAssignment;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.TrainingModule.Application.Tests.Services.TrainingCategoryAssignment
{
    public class InsertTrainingCategoryAssignmentCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITrainingCategoryAssignmentRepository> _repositoryMock;
        private readonly Mock<ILogger<TrainingCategoryAssignmentService>> _loggerMock;
        private readonly TrainingCategoryAssignmentService _service;
        public InsertTrainingCategoryAssignmentCommandTests()
        {
            _repositoryMock = new Mock<ITrainingCategoryAssignmentRepository>();
            _loggerMock = new Mock<ILogger<TrainingCategoryAssignmentService>>();
            _service = new TrainingCategoryAssignmentService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TrainingCategoryAssignmentDto>("tr");
            var fakeResponse = new RepoResponse<TrainingCategoryAssignmentDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TrainingCategoryAssignmentDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<TrainingCategoryAssignmentDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TrainingCategoryAssignmentDto>("tr");
            var fakeResponse = new RepoResponse<TrainingCategoryAssignmentDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TrainingCategoryAssignmentDto>())).ReturnsAsync(fakeResponse);
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