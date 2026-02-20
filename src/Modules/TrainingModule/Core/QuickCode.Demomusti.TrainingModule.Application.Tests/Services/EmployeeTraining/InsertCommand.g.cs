using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.TrainingModule.Application.Services.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.Common.Helpers;
using QuickCode.Demomusti.Common.Models;

namespace QuickCode.Demomusti.TrainingModule.Application.Tests.Services.EmployeeTraining
{
    public class InsertEmployeeTrainingCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IEmployeeTrainingRepository> _repositoryMock;
        private readonly Mock<ILogger<EmployeeTrainingService>> _loggerMock;
        private readonly EmployeeTrainingService _service;
        public InsertEmployeeTrainingCommandTests()
        {
            _repositoryMock = new Mock<IEmployeeTrainingRepository>();
            _loggerMock = new Mock<ILogger<EmployeeTrainingService>>();
            _service = new EmployeeTrainingService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<EmployeeTrainingDto>("tr");
            var fakeResponse = new RepoResponse<EmployeeTrainingDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<EmployeeTrainingDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<EmployeeTrainingDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<EmployeeTrainingDto>("tr");
            var fakeResponse = new RepoResponse<EmployeeTrainingDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<EmployeeTrainingDto>())).ReturnsAsync(fakeResponse);
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