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
    public partial interface IQualificationService
    {
        Task<Response<QualificationDto>> InsertAsync(QualificationDto request);
        Task<Response<bool>> DeleteAsync(QualificationDto request);
        Task<Response<bool>> UpdateAsync(int id, QualificationDto request);
        Task<Response<List<QualificationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<QualificationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int qualificationCandidateId, int? page, int? size);
    }
}