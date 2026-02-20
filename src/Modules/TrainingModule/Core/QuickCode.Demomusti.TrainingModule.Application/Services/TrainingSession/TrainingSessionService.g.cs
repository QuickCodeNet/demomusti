using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingSession;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingSession
{
    public partial class TrainingSessionService : ITrainingSessionService
    {
        private readonly ILogger<TrainingSessionService> _logger;
        private readonly ITrainingSessionRepository _repository;
        public TrainingSessionService(ILogger<TrainingSessionService> logger, ITrainingSessionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TrainingSessionDto>> InsertAsync(TrainingSessionDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TrainingSessionDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TrainingSessionDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TrainingSessionDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TrainingSessionDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int trainingSessionTrainingId, int? page, int? size)
        {
            var returnValue = await _repository.GetByTrainingAsync(trainingSessionTrainingId, page, size);
            return returnValue.ToResponse();
        }
    }
}