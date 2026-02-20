using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.Candidate;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.Candidate
{
    public partial class CandidateService : ICandidateService
    {
        private readonly ILogger<CandidateService> _logger;
        private readonly ICandidateRepository _repository;
        public CandidateService(ILogger<CandidateService> logger, ICandidateRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CandidateDto>> InsertAsync(CandidateDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CandidateDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CandidateDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CandidateDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CandidateDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool candidateIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(candidateIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string candidateFirstName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(candidateFirstName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ApplicationStatus candidateApplicationStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(candidateApplicationStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecentApplicationsResponseDto>>> GetRecentApplicationsAsync(int? page, int? size)
        {
            var returnValue = await _repository.GetRecentApplicationsAsync(page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetQualificationsForCandidatesResponseDto>>> GetQualificationsForCandidatesAsync(int candidatesId)
        {
            var returnValue = await _repository.GetQualificationsForCandidatesAsync(candidatesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetQualificationsForCandidatesResponseDto>> GetQualificationsForCandidatesDetailsAsync(int candidatesId, int qualificationsId)
        {
            var returnValue = await _repository.GetQualificationsForCandidatesDetailsAsync(candidatesId, qualificationsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetSkillsForCandidatesResponseDto>>> GetSkillsForCandidatesAsync(int candidatesId)
        {
            var returnValue = await _repository.GetSkillsForCandidatesAsync(candidatesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetSkillsForCandidatesResponseDto>> GetSkillsForCandidatesDetailsAsync(int candidatesId, int skillsId)
        {
            var returnValue = await _repository.GetSkillsForCandidatesDetailsAsync(candidatesId, skillsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetExperiencesForCandidatesResponseDto>>> GetExperiencesForCandidatesAsync(int candidatesId)
        {
            var returnValue = await _repository.GetExperiencesForCandidatesAsync(candidatesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetExperiencesForCandidatesResponseDto>> GetExperiencesForCandidatesDetailsAsync(int candidatesId, int experiencesId)
        {
            var returnValue = await _repository.GetExperiencesForCandidatesDetailsAsync(candidatesId, experiencesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetApplicationNotesForCandidatesResponseDto>>> GetApplicationNotesForCandidatesAsync(int candidatesId)
        {
            var returnValue = await _repository.GetApplicationNotesForCandidatesAsync(candidatesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetApplicationNotesForCandidatesResponseDto>> GetApplicationNotesForCandidatesDetailsAsync(int candidatesId, int applicationNotesId)
        {
            var returnValue = await _repository.GetApplicationNotesForCandidatesDetailsAsync(candidatesId, applicationNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCandidateSourcesForCandidatesResponseDto>>> GetCandidateSourcesForCandidatesAsync(int candidatesId)
        {
            var returnValue = await _repository.GetCandidateSourcesForCandidatesAsync(candidatesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCandidateSourcesForCandidatesResponseDto>> GetCandidateSourcesForCandidatesDetailsAsync(int candidatesId, int candidateSourcesId)
        {
            var returnValue = await _repository.GetCandidateSourcesForCandidatesDetailsAsync(candidatesId, candidateSourcesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int candidateId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(candidateId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int candidateId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(candidateId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int candidateId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(candidateId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}