using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.Training;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.Training
{
    public partial class TrainingService : ITrainingService
    {
        private readonly ILogger<TrainingService> _logger;
        private readonly ITrainingRepository _repository;
        public TrainingService(ILogger<TrainingService> logger, ITrainingRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TrainingDto>> InsertAsync(TrainingDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TrainingDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TrainingDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TrainingDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TrainingDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool trainingIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(trainingIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByTypeResponseDto>>> GetByTypeAsync(TrainingType trainingTrainingType, int? page, int? size)
        {
            var returnValue = await _repository.GetByTypeAsync(trainingTrainingType, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(TrainingStatus trainingStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(trainingStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetEmployeeTrainingsForTrainingResponseDto>>> GetEmployeeTrainingsForTrainingAsync(int trainingId)
        {
            var returnValue = await _repository.GetEmployeeTrainingsForTrainingAsync(trainingId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetEmployeeTrainingsForTrainingResponseDto>> GetEmployeeTrainingsForTrainingDetailsAsync(int trainingId, int employeeTrainingsId)
        {
            var returnValue = await _repository.GetEmployeeTrainingsForTrainingDetailsAsync(trainingId, employeeTrainingsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTrainingMaterialsForTrainingResponseDto>>> GetTrainingMaterialsForTrainingAsync(int trainingId)
        {
            var returnValue = await _repository.GetTrainingMaterialsForTrainingAsync(trainingId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetTrainingMaterialsForTrainingResponseDto>> GetTrainingMaterialsForTrainingDetailsAsync(int trainingId, int trainingMaterialsId)
        {
            var returnValue = await _repository.GetTrainingMaterialsForTrainingDetailsAsync(trainingId, trainingMaterialsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTrainingSessionsForTrainingResponseDto>>> GetTrainingSessionsForTrainingAsync(int trainingId)
        {
            var returnValue = await _repository.GetTrainingSessionsForTrainingAsync(trainingId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetTrainingSessionsForTrainingResponseDto>> GetTrainingSessionsForTrainingDetailsAsync(int trainingId, int trainingSessionsId)
        {
            var returnValue = await _repository.GetTrainingSessionsForTrainingDetailsAsync(trainingId, trainingSessionsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTrainingCategoryAssignmentsForTrainingResponseDto>>> GetTrainingCategoryAssignmentsForTrainingAsync(int trainingId)
        {
            var returnValue = await _repository.GetTrainingCategoryAssignmentsForTrainingAsync(trainingId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetTrainingCategoryAssignmentsForTrainingResponseDto>> GetTrainingCategoryAssignmentsForTrainingDetailsAsync(int trainingId, int trainingCategoryAssignmentsId)
        {
            var returnValue = await _repository.GetTrainingCategoryAssignmentsForTrainingDetailsAsync(trainingId, trainingCategoryAssignmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int trainingId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(trainingId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}