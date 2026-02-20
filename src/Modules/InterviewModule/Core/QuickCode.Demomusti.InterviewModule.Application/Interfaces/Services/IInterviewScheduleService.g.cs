using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewSchedule;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.InterviewSchedule
{
    public partial interface IInterviewScheduleService
    {
        Task<Response<InterviewScheduleDto>> InsertAsync(InterviewScheduleDto request);
        Task<Response<bool>> DeleteAsync(InterviewScheduleDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewScheduleDto request);
        Task<Response<List<InterviewScheduleDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewScheduleDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByInterviewResponseDto>>> GetByInterviewAsync(int interviewScheduleInterviewId, int? page, int? size);
    }
}