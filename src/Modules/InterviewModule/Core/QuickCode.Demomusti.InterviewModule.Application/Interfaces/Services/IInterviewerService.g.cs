using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.Interviewer;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.Interviewer
{
    public partial interface IInterviewerService
    {
        Task<Response<InterviewerDto>> InsertAsync(InterviewerDto request);
        Task<Response<bool>> DeleteAsync(InterviewerDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewerDto request);
        Task<Response<List<InterviewerDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewerDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool interviewerIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string interviewerFirstName, int? page, int? size);
        Task<Response<List<GetInterviewsForInterviewersResponseDto>>> GetInterviewsForInterviewersAsync(int interviewersId);
        Task<Response<GetInterviewsForInterviewersResponseDto>> GetInterviewsForInterviewersDetailsAsync(int interviewersId, int interviewsId);
        Task<Response<int>> ActivateAsync(int interviewerId, ActivateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int interviewerId, DeactivateRequestDto updateRequest);
    }
}