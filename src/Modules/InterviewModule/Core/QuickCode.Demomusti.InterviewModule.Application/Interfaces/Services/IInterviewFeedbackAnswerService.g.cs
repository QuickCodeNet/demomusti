using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewFeedbackAnswer;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.InterviewFeedbackAnswer
{
    public partial interface IInterviewFeedbackAnswerService
    {
        Task<Response<InterviewFeedbackAnswerDto>> InsertAsync(InterviewFeedbackAnswerDto request);
        Task<Response<bool>> DeleteAsync(InterviewFeedbackAnswerDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewFeedbackAnswerDto request);
        Task<Response<List<InterviewFeedbackAnswerDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewFeedbackAnswerDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByInterviewResponseDto>>> GetByInterviewAsync(int interviewFeedbackAnswerInterviewId, int? page, int? size);
    }
}