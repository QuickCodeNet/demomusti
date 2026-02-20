using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.CandidateSource;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.CandidateSource
{
    public partial interface ICandidateSourceService
    {
        Task<Response<CandidateSourceDto>> InsertAsync(CandidateSourceDto request);
        Task<Response<bool>> DeleteAsync(CandidateSourceDto request);
        Task<Response<bool>> UpdateAsync(int id, CandidateSourceDto request);
        Task<Response<List<CandidateSourceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CandidateSourceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int candidateSourceCandidateId, int? page, int? size);
    }
}