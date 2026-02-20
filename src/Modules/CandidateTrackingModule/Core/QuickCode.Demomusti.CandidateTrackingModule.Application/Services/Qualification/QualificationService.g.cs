using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.Qualification;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.Qualification
{
    public partial class QualificationService : IQualificationService
    {
        private readonly ILogger<QualificationService> _logger;
        private readonly IQualificationRepository _repository;
        public QualificationService(ILogger<QualificationService> logger, IQualificationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<QualificationDto>> InsertAsync(QualificationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(QualificationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, QualificationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<QualificationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<QualificationDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int qualificationCandidateId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCandidateAsync(qualificationCandidateId, page, size);
            return returnValue.ToResponse();
        }
    }
}