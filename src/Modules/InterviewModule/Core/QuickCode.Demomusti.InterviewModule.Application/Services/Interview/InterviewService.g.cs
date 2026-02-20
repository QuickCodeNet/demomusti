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
    public partial class InterviewService : IInterviewService
    {
        private readonly ILogger<InterviewService> _logger;
        private readonly IInterviewRepository _repository;
        public InterviewService(ILogger<InterviewService> logger, IInterviewRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<InterviewDto>> InsertAsync(InterviewDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(InterviewDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, InterviewDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<InterviewDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<InterviewDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int interviewCandidateId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCandidateAsync(interviewCandidateId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByInterviewerResponseDto>>> GetByInterviewerAsync(int interviewInterviewerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByInterviewerAsync(interviewInterviewerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetScheduledResponseDto>>> GetScheduledAsync(InterviewStatus interviewInterviewStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetScheduledAsync(interviewInterviewStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCompletedResponseDto>>> GetCompletedAsync(InterviewStatus interviewInterviewStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetCompletedAsync(interviewInterviewStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetInterviewFeedbackAnswersForInterviewsResponseDto>>> GetInterviewFeedbackAnswersForInterviewsAsync(int interviewsId)
        {
            var returnValue = await _repository.GetInterviewFeedbackAnswersForInterviewsAsync(interviewsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetInterviewFeedbackAnswersForInterviewsResponseDto>> GetInterviewFeedbackAnswersForInterviewsDetailsAsync(int interviewsId, int interviewFeedbackAnswersId)
        {
            var returnValue = await _repository.GetInterviewFeedbackAnswersForInterviewsDetailsAsync(interviewsId, interviewFeedbackAnswersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetInterviewSchedulesForInterviewsResponseDto>>> GetInterviewSchedulesForInterviewsAsync(int interviewsId)
        {
            var returnValue = await _repository.GetInterviewSchedulesForInterviewsAsync(interviewsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetInterviewSchedulesForInterviewsResponseDto>> GetInterviewSchedulesForInterviewsDetailsAsync(int interviewsId, int interviewSchedulesId)
        {
            var returnValue = await _repository.GetInterviewSchedulesForInterviewsDetailsAsync(interviewsId, interviewSchedulesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetInterviewNotesForInterviewsResponseDto>>> GetInterviewNotesForInterviewsAsync(int interviewsId)
        {
            var returnValue = await _repository.GetInterviewNotesForInterviewsAsync(interviewsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetInterviewNotesForInterviewsResponseDto>> GetInterviewNotesForInterviewsDetailsAsync(int interviewsId, int interviewNotesId)
        {
            var returnValue = await _repository.GetInterviewNotesForInterviewsDetailsAsync(interviewsId, interviewNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int interviewId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(interviewId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> AddFeedbackAsync(int interviewId, AddFeedbackRequestDto updateRequest)
        {
            var returnValue = await _repository.AddFeedbackAsync(interviewId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}