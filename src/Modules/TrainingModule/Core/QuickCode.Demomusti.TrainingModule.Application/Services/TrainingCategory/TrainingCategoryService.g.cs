using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategory;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategory
{
    public partial class TrainingCategoryService : ITrainingCategoryService
    {
        private readonly ILogger<TrainingCategoryService> _logger;
        private readonly ITrainingCategoryRepository _repository;
        public TrainingCategoryService(ILogger<TrainingCategoryService> logger, ITrainingCategoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TrainingCategoryDto>> InsertAsync(TrainingCategoryDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TrainingCategoryDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TrainingCategoryDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TrainingCategoryDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TrainingCategoryDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetAllResponseDto>>> GetAllAsync()
        {
            var returnValue = await _repository.GetAllAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto>>> GetTrainingCategoryAssignmentsForTrainingCategoriesAsync(int trainingCategoriesId)
        {
            var returnValue = await _repository.GetTrainingCategoryAssignmentsForTrainingCategoriesAsync(trainingCategoriesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto>> GetTrainingCategoryAssignmentsForTrainingCategoriesDetailsAsync(int trainingCategoriesId, int trainingCategoryAssignmentsId)
        {
            var returnValue = await _repository.GetTrainingCategoryAssignmentsForTrainingCategoriesDetailsAsync(trainingCategoriesId, trainingCategoryAssignmentsId);
            return returnValue.ToResponse();
        }
    }
}