using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.Common.Controllers;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Application.Services.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Api.Controllers
{
    public partial class EmployeeTrainingsController : QuickCodeBaseApiController
    {
        private readonly IEmployeeTrainingService service;
        private readonly ILogger<EmployeeTrainingsController> logger;
        private readonly IServiceProvider serviceProvider;
        public EmployeeTrainingsController(IEmployeeTrainingService service, IServiceProvider serviceProvider, ILogger<EmployeeTrainingsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeTrainingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "EmployeeTraining", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "EmployeeTraining") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeTrainingDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmployeeTrainingDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(EmployeeTrainingDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "EmployeeTraining") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, EmployeeTrainingDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "EmployeeTraining", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-employee/{employeeTrainingEmployeeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByEmployeeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByEmployeeAsync(int employeeTrainingEmployeeId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByEmployeeAsync(employeeTrainingEmployeeId, page, size);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"EmployeeTrainingEmployeeId: '{employeeTrainingEmployeeId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-training/{employeeTrainingTrainingId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByTrainingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByTrainingAsync(int employeeTrainingTrainingId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByTrainingAsync(employeeTrainingTrainingId, page, size);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"EmployeeTrainingTrainingId: '{employeeTrainingTrainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{employeeTrainingId}/training-feedback")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTrainingFeedbacksForEmployeeTrainingsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingFeedbacksForEmployeeTrainingsAsync(int employeeTrainingsId)
        {
            var response = await service.GetTrainingFeedbacksForEmployeeTrainingsAsync(employeeTrainingsId);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"EmployeeTrainingsId: '{employeeTrainingsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{employeeTrainingId}/training-feedback/{trainingFeedbackId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTrainingFeedbacksForEmployeeTrainingsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingFeedbacksForEmployeeTrainingsDetailsAsync(int employeeTrainingsId, int trainingFeedbacksId)
        {
            var response = await service.GetTrainingFeedbacksForEmployeeTrainingsDetailsAsync(employeeTrainingsId, trainingFeedbacksId);
            if (HandleResponseError(response, logger, "EmployeeTraining", $"EmployeeTrainingsId: '{employeeTrainingsId}', TrainingFeedbacksId: '{trainingFeedbacksId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}