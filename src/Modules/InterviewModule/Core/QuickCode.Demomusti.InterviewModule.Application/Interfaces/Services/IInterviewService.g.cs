using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.Interview;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.Interview
{
    public partial interface IInterviewService
    {
        Task<Response<InterviewDto>> InsertAsync(InterviewDto request);
        Task<Response<bool>> DeleteAsync(InterviewDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewDto request);
        Task<Response<List<InterviewDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int interviewCandidateId, int? page, int? size);
        Task<Response<List<GetByInterviewerResponseDto>>> GetByInterviewerAsync(int interviewInterviewerId, int? page, int? size);
        Task<Response<List<GetScheduledResponseDto>>> GetScheduledAsync(InterviewStatus interviewInterviewStatus, int? page, int? size);
        Task<Response<List<GetCompletedResponseDto>>> GetCompletedAsync(InterviewStatus interviewInterviewStatus, int? page, int? size);
        Task<Response<List<GetInterviewFeedbackAnswersForInterviewsResponseDto>>> GetInterviewFeedbackAnswersForInterviewsAsync(int interviewsId);
        Task<Response<GetInterviewFeedbackAnswersForInterviewsResponseDto>> GetInterviewFeedbackAnswersForInterviewsDetailsAsync(int interviewsId, int interviewFeedbackAnswersId);
        Task<Response<List<GetInterviewSchedulesForInterviewsResponseDto>>> GetInterviewSchedulesForInterviewsAsync(int interviewsId);
        Task<Response<GetInterviewSchedulesForInterviewsResponseDto>> GetInterviewSchedulesForInterviewsDetailsAsync(int interviewsId, int interviewSchedulesId);
        Task<Response<List<GetInterviewNotesForInterviewsResponseDto>>> GetInterviewNotesForInterviewsAsync(int interviewsId);
        Task<Response<GetInterviewNotesForInterviewsResponseDto>> GetInterviewNotesForInterviewsDetailsAsync(int interviewsId, int interviewNotesId);
        Task<Response<int>> UpdateStatusAsync(int interviewId, UpdateStatusRequestDto updateRequest);
        Task<Response<int>> AddFeedbackAsync(int interviewId, AddFeedbackRequestDto updateRequest);
    }
}