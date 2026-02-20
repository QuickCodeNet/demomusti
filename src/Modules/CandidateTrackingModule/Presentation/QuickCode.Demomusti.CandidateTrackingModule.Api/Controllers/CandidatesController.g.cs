using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.Common.Controllers;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.Candidate;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Services.Candidate;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Api.Controllers
{
    public partial class CandidatesController : QuickCodeBaseApiController
    {
        private readonly ICandidateService service;
        private readonly ILogger<CandidatesController> logger;
        private readonly IServiceProvider serviceProvider;
        public CandidatesController(ICandidateService service, IServiceProvider serviceProvider, ILogger<CandidatesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CandidateDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Candidate", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Candidate") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CandidateDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Candidate", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CandidateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CandidateDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Candidate") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CandidateDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Candidate", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "Candidate", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{candidateIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool candidateIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(candidateIsActive, page, size);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateIsActive: '{candidateIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{candidateFirstName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string candidateFirstName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(candidateFirstName, page, size);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateFirstName: '{candidateFirstName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{candidateApplicationStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(ApplicationStatus candidateApplicationStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(candidateApplicationStatus, page, size);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateApplicationStatus: '{candidateApplicationStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-recent-applications")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecentApplicationsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecentApplicationsAsync(int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetRecentApplicationsAsync(page, size);
            if (HandleResponseError(response, logger, "Candidate", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/qualification")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetQualificationsForCandidatesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetQualificationsForCandidatesAsync(int candidatesId)
        {
            var response = await service.GetQualificationsForCandidatesAsync(candidatesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/qualification/{qualificationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetQualificationsForCandidatesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetQualificationsForCandidatesDetailsAsync(int candidatesId, int qualificationsId)
        {
            var response = await service.GetQualificationsForCandidatesDetailsAsync(candidatesId, qualificationsId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}', QualificationsId: '{qualificationsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/skill")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetSkillsForCandidatesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSkillsForCandidatesAsync(int candidatesId)
        {
            var response = await service.GetSkillsForCandidatesAsync(candidatesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/skill/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetSkillsForCandidatesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSkillsForCandidatesDetailsAsync(int candidatesId, int skillsId)
        {
            var response = await service.GetSkillsForCandidatesDetailsAsync(candidatesId, skillsId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}', SkillsId: '{skillsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/experience")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetExperiencesForCandidatesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetExperiencesForCandidatesAsync(int candidatesId)
        {
            var response = await service.GetExperiencesForCandidatesAsync(candidatesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/experience/{experienceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetExperiencesForCandidatesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetExperiencesForCandidatesDetailsAsync(int candidatesId, int experiencesId)
        {
            var response = await service.GetExperiencesForCandidatesDetailsAsync(candidatesId, experiencesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}', ExperiencesId: '{experiencesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/application-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetApplicationNotesForCandidatesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetApplicationNotesForCandidatesAsync(int candidatesId)
        {
            var response = await service.GetApplicationNotesForCandidatesAsync(candidatesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/application-note/{applicationNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetApplicationNotesForCandidatesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetApplicationNotesForCandidatesDetailsAsync(int candidatesId, int applicationNotesId)
        {
            var response = await service.GetApplicationNotesForCandidatesDetailsAsync(candidatesId, applicationNotesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}', ApplicationNotesId: '{applicationNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/candidate-source")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCandidateSourcesForCandidatesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCandidateSourcesForCandidatesAsync(int candidatesId)
        {
            var response = await service.GetCandidateSourcesForCandidatesAsync(candidatesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{candidateId}/candidate-source/{candidateSourceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCandidateSourcesForCandidatesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCandidateSourcesForCandidatesDetailsAsync(int candidatesId, int candidateSourcesId)
        {
            var response = await service.GetCandidateSourcesForCandidatesDetailsAsync(candidatesId, candidateSourcesId);
            if (HandleResponseError(response, logger, "Candidate", $"CandidatesId: '{candidatesId}', CandidateSourcesId: '{candidateSourcesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{candidateId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int candidateId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(candidateId, updateRequest);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateId: '{candidateId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("activate/{candidateId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ActivateAsync(int candidateId, [FromBody] ActivateRequestDto updateRequest)
        {
            var response = await service.ActivateAsync(candidateId, updateRequest);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateId: '{candidateId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{candidateId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int candidateId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(candidateId, updateRequest);
            if (HandleResponseError(response, logger, "Candidate", $"CandidateId: '{candidateId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}