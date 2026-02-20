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
    public partial class InterviewFeedbackAnswerService : IInterviewFeedbackAnswerService
    {
        private readonly ILogger<InterviewFeedbackAnswerService> _logger;
        private readonly IInterviewFeedbackAnswerRepository _repository;
        public InterviewFeedbackAnswerService(ILogger<InterviewFeedbackAnswerService> logger, IInterviewFeedbackAnswerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<InterviewFeedbackAnswerDto>> InsertAsync(InterviewFeedbackAnswerDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(InterviewFeedbackAnswerDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, InterviewFeedbackAnswerDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<InterviewFeedbackAnswerDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<InterviewFeedbackAnswerDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByInterviewResponseDto>>> GetByInterviewAsync(int interviewFeedbackAnswerInterviewId, int? page, int? size)
        {
            var returnValue = await _repository.GetByInterviewAsync(interviewFeedbackAnswerInterviewId, page, size);
            return returnValue.ToResponse();
        }
    }
}