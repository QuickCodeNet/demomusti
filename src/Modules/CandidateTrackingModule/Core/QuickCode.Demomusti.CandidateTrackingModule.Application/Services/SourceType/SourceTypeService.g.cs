using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.SourceType;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.SourceType
{
    public partial class SourceTypeService : ISourceTypeService
    {
        private readonly ILogger<SourceTypeService> _logger;
        private readonly ISourceTypeRepository _repository;
        public SourceTypeService(ILogger<SourceTypeService> logger, ISourceTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<SourceTypeDto>> InsertAsync(SourceTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(SourceTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, SourceTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SourceTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<SourceTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetCandidateSourcesForSourceTypesResponseDto>>> GetCandidateSourcesForSourceTypesAsync(int sourceTypesId)
        {
            var returnValue = await _repository.GetCandidateSourcesForSourceTypesAsync(sourceTypesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCandidateSourcesForSourceTypesResponseDto>> GetCandidateSourcesForSourceTypesDetailsAsync(int sourceTypesId, int candidateSourcesId)
        {
            var returnValue = await _repository.GetCandidateSourcesForSourceTypesDetailsAsync(sourceTypesId, candidateSourcesId);
            return returnValue.ToResponse();
        }
    }
}