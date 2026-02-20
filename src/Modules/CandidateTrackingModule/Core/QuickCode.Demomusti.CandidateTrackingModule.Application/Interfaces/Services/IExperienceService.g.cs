using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.Experience;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.Experience
{
    public partial interface IExperienceService
    {
        Task<Response<ExperienceDto>> InsertAsync(ExperienceDto request);
        Task<Response<bool>> DeleteAsync(ExperienceDto request);
        Task<Response<bool>> UpdateAsync(int id, ExperienceDto request);
        Task<Response<List<ExperienceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ExperienceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int experienceCandidateId, int? page, int? size);
    }
}