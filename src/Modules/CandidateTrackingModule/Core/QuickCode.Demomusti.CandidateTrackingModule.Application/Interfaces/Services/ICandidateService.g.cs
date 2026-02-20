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
    public partial interface ICandidateService
    {
        Task<Response<CandidateDto>> InsertAsync(CandidateDto request);
        Task<Response<bool>> DeleteAsync(CandidateDto request);
        Task<Response<bool>> UpdateAsync(int id, CandidateDto request);
        Task<Response<List<CandidateDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CandidateDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool candidateIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string candidateFirstName, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ApplicationStatus candidateApplicationStatus, int? page, int? size);
        Task<Response<List<GetRecentApplicationsResponseDto>>> GetRecentApplicationsAsync(int? page, int? size);
        Task<Response<List<GetQualificationsForCandidatesResponseDto>>> GetQualificationsForCandidatesAsync(int candidatesId);
        Task<Response<GetQualificationsForCandidatesResponseDto>> GetQualificationsForCandidatesDetailsAsync(int candidatesId, int qualificationsId);
        Task<Response<List<GetSkillsForCandidatesResponseDto>>> GetSkillsForCandidatesAsync(int candidatesId);
        Task<Response<GetSkillsForCandidatesResponseDto>> GetSkillsForCandidatesDetailsAsync(int candidatesId, int skillsId);
        Task<Response<List<GetExperiencesForCandidatesResponseDto>>> GetExperiencesForCandidatesAsync(int candidatesId);
        Task<Response<GetExperiencesForCandidatesResponseDto>> GetExperiencesForCandidatesDetailsAsync(int candidatesId, int experiencesId);
        Task<Response<List<GetApplicationNotesForCandidatesResponseDto>>> GetApplicationNotesForCandidatesAsync(int candidatesId);
        Task<Response<GetApplicationNotesForCandidatesResponseDto>> GetApplicationNotesForCandidatesDetailsAsync(int candidatesId, int applicationNotesId);
        Task<Response<List<GetCandidateSourcesForCandidatesResponseDto>>> GetCandidateSourcesForCandidatesAsync(int candidatesId);
        Task<Response<GetCandidateSourcesForCandidatesResponseDto>> GetCandidateSourcesForCandidatesDetailsAsync(int candidatesId, int candidateSourcesId);
        Task<Response<int>> UpdateStatusAsync(int candidateId, UpdateStatusRequestDto updateRequest);
        Task<Response<int>> ActivateAsync(int candidateId, ActivateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int candidateId, DeactivateRequestDto updateRequest);
    }
}