using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.Skill;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.Skill
{
    public partial interface ISkillService
    {
        Task<Response<SkillDto>> InsertAsync(SkillDto request);
        Task<Response<bool>> DeleteAsync(SkillDto request);
        Task<Response<bool>> UpdateAsync(int id, SkillDto request);
        Task<Response<List<SkillDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SkillDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int skillCandidateId, int? page, int? size);
    }
}