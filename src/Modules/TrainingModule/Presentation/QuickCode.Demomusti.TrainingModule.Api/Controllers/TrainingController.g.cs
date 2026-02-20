using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.Common.Controllers;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.Training;
using QuickCode.Demomusti.TrainingModule.Application.Services.Training;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Api.Controllers
{
    public partial class TrainingController : QuickCodeBaseApiController
    {
        private readonly ITrainingService service;
        private readonly ILogger<TrainingController> logger;
        private readonly IServiceProvider serviceProvider;
        public TrainingController(ITrainingService service, IServiceProvider serviceProvider, ILogger<TrainingController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TrainingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Training", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Training") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainingDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Training", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TrainingDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TrainingDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Training") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, TrainingDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Training", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Training", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{trainingIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool trainingIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(trainingIsActive, page, size);
            if (HandleResponseError(response, logger, "Training", $"TrainingIsActive: '{trainingIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-type/{trainingTrainingType}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByTypeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByTypeAsync(TrainingType trainingTrainingType, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByTypeAsync(trainingTrainingType, page, size);
            if (HandleResponseError(response, logger, "Training", $"TrainingTrainingType: '{trainingTrainingType}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{trainingStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(TrainingStatus trainingStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(trainingStatus, page, size);
            if (HandleResponseError(response, logger, "Training", $"TrainingStatus: '{trainingStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/employee-training")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetEmployeeTrainingsForTrainingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetEmployeeTrainingsForTrainingAsync(int trainingId)
        {
            var response = await service.GetEmployeeTrainingsForTrainingAsync(trainingId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/employee-training/{employeeTrainingId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeeTrainingsForTrainingResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetEmployeeTrainingsForTrainingDetailsAsync(int trainingId, int employeeTrainingsId)
        {
            var response = await service.GetEmployeeTrainingsForTrainingDetailsAsync(trainingId, employeeTrainingsId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}', EmployeeTrainingsId: '{employeeTrainingsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-material")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTrainingMaterialsForTrainingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingMaterialsForTrainingAsync(int trainingId)
        {
            var response = await service.GetTrainingMaterialsForTrainingAsync(trainingId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-material/{trainingMaterialId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTrainingMaterialsForTrainingResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingMaterialsForTrainingDetailsAsync(int trainingId, int trainingMaterialsId)
        {
            var response = await service.GetTrainingMaterialsForTrainingDetailsAsync(trainingId, trainingMaterialsId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}', TrainingMaterialsId: '{trainingMaterialsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-session")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTrainingSessionsForTrainingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingSessionsForTrainingAsync(int trainingId)
        {
            var response = await service.GetTrainingSessionsForTrainingAsync(trainingId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-session/{trainingSessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTrainingSessionsForTrainingResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingSessionsForTrainingDetailsAsync(int trainingId, int trainingSessionsId)
        {
            var response = await service.GetTrainingSessionsForTrainingDetailsAsync(trainingId, trainingSessionsId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}', TrainingSessionsId: '{trainingSessionsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-category-assignment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTrainingCategoryAssignmentsForTrainingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingCategoryAssignmentsForTrainingAsync(int trainingId)
        {
            var response = await service.GetTrainingCategoryAssignmentsForTrainingAsync(trainingId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingId}/training-category-assignment/{trainingCategoryAssignmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTrainingCategoryAssignmentsForTrainingResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingCategoryAssignmentsForTrainingDetailsAsync(int trainingId, int trainingCategoryAssignmentsId)
        {
            var response = await service.GetTrainingCategoryAssignmentsForTrainingDetailsAsync(trainingId, trainingCategoryAssignmentsId);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}', TrainingCategoryAssignmentsId: '{trainingCategoryAssignmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{trainingId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int trainingId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(trainingId, updateRequest);
            if (HandleResponseError(response, logger, "Training", $"TrainingId: '{trainingId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}