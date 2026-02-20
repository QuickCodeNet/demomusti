using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingFeedback;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingFeedback
{
    public partial class TrainingFeedbackService : ITrainingFeedbackService
    {
        private readonly ILogger<TrainingFeedbackService> _logger;
        private readonly ITrainingFeedbackRepository _repository;
        public TrainingFeedbackService(ILogger<TrainingFeedbackService> logger, ITrainingFeedbackRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TrainingFeedbackDto>> InsertAsync(TrainingFeedbackDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TrainingFeedbackDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TrainingFeedbackDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TrainingFeedbackDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TrainingFeedbackDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByEmployeeTrainingResponseDto>>> GetByEmployeeTrainingAsync(int trainingFeedbackEmployeeTrainingId, int? page, int? size)
        {
            var returnValue = await _repository.GetByEmployeeTrainingAsync(trainingFeedbackEmployeeTrainingId, page, size);
            return returnValue.ToResponse();
        }
    }
}