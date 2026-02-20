using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategoryAssignment;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategoryAssignment
{
    public partial class TrainingCategoryAssignmentService : ITrainingCategoryAssignmentService
    {
        private readonly ILogger<TrainingCategoryAssignmentService> _logger;
        private readonly ITrainingCategoryAssignmentRepository _repository;
        public TrainingCategoryAssignmentService(ILogger<TrainingCategoryAssignmentService> logger, ITrainingCategoryAssignmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TrainingCategoryAssignmentDto>> InsertAsync(TrainingCategoryAssignmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TrainingCategoryAssignmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TrainingCategoryAssignmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TrainingCategoryAssignmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TrainingCategoryAssignmentDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int trainingCategoryAssignmentTrainingId, int? page, int? size)
        {
            var returnValue = await _repository.GetByTrainingAsync(trainingCategoryAssignmentTrainingId, page, size);
            return returnValue.ToResponse();
        }
    }
}