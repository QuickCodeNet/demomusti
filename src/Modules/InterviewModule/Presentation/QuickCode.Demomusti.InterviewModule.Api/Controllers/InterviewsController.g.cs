using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.Common.Controllers;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.Interview;
using QuickCode.Demomusti.InterviewModule.Application.Services.Interview;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Api.Controllers
{
    public partial class InterviewsController : QuickCodeBaseApiController
    {
        private readonly IInterviewService service;
        private readonly ILogger<InterviewsController> logger;
        private readonly IServiceProvider serviceProvider;
        public InterviewsController(IInterviewService service, IServiceProvider serviceProvider, ILogger<InterviewsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InterviewDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Interview", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Interview") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Interview", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InterviewDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(InterviewDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Interview") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, InterviewDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Interview", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Interview", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-candidate/{interviewCandidateId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCandidateResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCandidateAsync(int interviewCandidateId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCandidateAsync(interviewCandidateId, page, size);
            if (HandleResponseError(response, logger, "Interview", $"InterviewCandidateId: '{interviewCandidateId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-interviewer/{interviewInterviewerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByInterviewerResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByInterviewerAsync(int interviewInterviewerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByInterviewerAsync(interviewInterviewerId, page, size);
            if (HandleResponseError(response, logger, "Interview", $"InterviewInterviewerId: '{interviewInterviewerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-scheduled/{interviewInterviewStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetScheduledResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetScheduledAsync(InterviewStatus interviewInterviewStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetScheduledAsync(interviewInterviewStatus, page, size);
            if (HandleResponseError(response, logger, "Interview", $"InterviewInterviewStatus: '{interviewInterviewStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-completed/{interviewInterviewStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCompletedResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCompletedAsync(InterviewStatus interviewInterviewStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetCompletedAsync(interviewInterviewStatus, page, size);
            if (HandleResponseError(response, logger, "Interview", $"InterviewInterviewStatus: '{interviewInterviewStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-feedback-answer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetInterviewFeedbackAnswersForInterviewsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewFeedbackAnswersForInterviewsAsync(int interviewsId)
        {
            var response = await service.GetInterviewFeedbackAnswersForInterviewsAsync(interviewsId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-feedback-answer/{interviewFeedbackAnswerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInterviewFeedbackAnswersForInterviewsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewFeedbackAnswersForInterviewsDetailsAsync(int interviewsId, int interviewFeedbackAnswersId)
        {
            var response = await service.GetInterviewFeedbackAnswersForInterviewsDetailsAsync(interviewsId, interviewFeedbackAnswersId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}', InterviewFeedbackAnswersId: '{interviewFeedbackAnswersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-schedule")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetInterviewSchedulesForInterviewsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewSchedulesForInterviewsAsync(int interviewsId)
        {
            var response = await service.GetInterviewSchedulesForInterviewsAsync(interviewsId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-schedule/{interviewScheduleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInterviewSchedulesForInterviewsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewSchedulesForInterviewsDetailsAsync(int interviewsId, int interviewSchedulesId)
        {
            var response = await service.GetInterviewSchedulesForInterviewsDetailsAsync(interviewsId, interviewSchedulesId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}', InterviewSchedulesId: '{interviewSchedulesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetInterviewNotesForInterviewsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewNotesForInterviewsAsync(int interviewsId)
        {
            var response = await service.GetInterviewNotesForInterviewsAsync(interviewsId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{interviewId}/interview-note/{interviewNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInterviewNotesForInterviewsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInterviewNotesForInterviewsDetailsAsync(int interviewsId, int interviewNotesId)
        {
            var response = await service.GetInterviewNotesForInterviewsDetailsAsync(interviewsId, interviewNotesId);
            if (HandleResponseError(response, logger, "Interview", $"InterviewsId: '{interviewsId}', InterviewNotesId: '{interviewNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{interviewId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int interviewId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(interviewId, updateRequest);
            if (HandleResponseError(response, logger, "Interview", $"InterviewId: '{interviewId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("add-feedback/{interviewId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddFeedbackAsync(int interviewId, [FromBody] AddFeedbackRequestDto updateRequest)
        {
            var response = await service.AddFeedbackAsync(interviewId, updateRequest);
            if (HandleResponseError(response, logger, "Interview", $"InterviewId: '{interviewId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}