using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.EmployeeTraining
{
    public partial class EmployeeTrainingService : IEmployeeTrainingService
    {
        private readonly ILogger<EmployeeTrainingService> _logger;
        private readonly IEmployeeTrainingRepository _repository;
        public EmployeeTrainingService(ILogger<EmployeeTrainingService> logger, IEmployeeTrainingRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<EmployeeTrainingDto>> InsertAsync(EmployeeTrainingDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(EmployeeTrainingDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, EmployeeTrainingDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<EmployeeTrainingDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<EmployeeTrainingDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByEmployeeResponseDto>>> GetByEmployeeAsync(int employeeTrainingEmployeeId, int? page, int? size)
        {
            var returnValue = await _repository.GetByEmployeeAsync(employeeTrainingEmployeeId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int employeeTrainingTrainingId, int? page, int? size)
        {
            var returnValue = await _repository.GetByTrainingAsync(employeeTrainingTrainingId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTrainingFeedbacksForEmployeeTrainingsResponseDto>>> GetTrainingFeedbacksForEmployeeTrainingsAsync(int employeeTrainingsId)
        {
            var returnValue = await _repository.GetTrainingFeedbacksForEmployeeTrainingsAsync(employeeTrainingsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetTrainingFeedbacksForEmployeeTrainingsResponseDto>> GetTrainingFeedbacksForEmployeeTrainingsDetailsAsync(int employeeTrainingsId, int trainingFeedbacksId)
        {
            var returnValue = await _repository.GetTrainingFeedbacksForEmployeeTrainingsDetailsAsync(employeeTrainingsId, trainingFeedbacksId);
            return returnValue.ToResponse();
        }
    }
}