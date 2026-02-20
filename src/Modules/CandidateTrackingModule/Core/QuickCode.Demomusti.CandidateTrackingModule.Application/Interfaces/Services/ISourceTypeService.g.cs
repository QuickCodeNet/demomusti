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
    public partial interface ISourceTypeService
    {
        Task<Response<SourceTypeDto>> InsertAsync(SourceTypeDto request);
        Task<Response<bool>> DeleteAsync(SourceTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, SourceTypeDto request);
        Task<Response<List<SourceTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SourceTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
        Task<Response<List<GetCandidateSourcesForSourceTypesResponseDto>>> GetCandidateSourcesForSourceTypesAsync(int sourceTypesId);
        Task<Response<GetCandidateSourcesForSourceTypesResponseDto>> GetCandidateSourcesForSourceTypesDetailsAsync(int sourceTypesId, int candidateSourcesId);
    }
}