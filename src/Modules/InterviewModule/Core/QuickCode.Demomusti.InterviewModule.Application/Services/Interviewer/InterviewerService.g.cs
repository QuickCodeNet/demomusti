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
    public partial class InterviewerService : IInterviewerService
    {
        private readonly ILogger<InterviewerService> _logger;
        private readonly IInterviewerRepository _repository;
        public InterviewerService(ILogger<InterviewerService> logger, IInterviewerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<InterviewerDto>> InsertAsync(InterviewerDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(InterviewerDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, InterviewerDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<InterviewerDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<InterviewerDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool interviewerIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(interviewerIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string interviewerFirstName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(interviewerFirstName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetInterviewsForInterviewersResponseDto>>> GetInterviewsForInterviewersAsync(int interviewersId)
        {
            var returnValue = await _repository.GetInterviewsForInterviewersAsync(interviewersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetInterviewsForInterviewersResponseDto>> GetInterviewsForInterviewersDetailsAsync(int interviewersId, int interviewsId)
        {
            var returnValue = await _repository.GetInterviewsForInterviewersDetailsAsync(interviewersId, interviewsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int interviewerId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(interviewerId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int interviewerId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(interviewerId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}