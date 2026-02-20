using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewFeedbackQuestion;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.InterviewFeedbackQuestion
{
    public partial interface IInterviewFeedbackQuestionService
    {
        Task<Response<InterviewFeedbackQuestionDto>> InsertAsync(InterviewFeedbackQuestionDto request);
        Task<Response<bool>> DeleteAsync(InterviewFeedbackQuestionDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewFeedbackQuestionDto request);
        Task<Response<List<InterviewFeedbackQuestionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewFeedbackQuestionDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
        Task<Response<List<GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsResponseDto>>> GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsAsync(int interviewFeedbackQuestionsId);
        Task<Response<GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsResponseDto>> GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsDetailsAsync(int interviewFeedbackQuestionsId, int interviewFeedbackAnswersId);
    }
}