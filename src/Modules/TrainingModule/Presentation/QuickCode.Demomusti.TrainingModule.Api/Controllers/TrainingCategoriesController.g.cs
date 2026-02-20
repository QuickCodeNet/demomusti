using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demomusti.Common.Controllers;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategory;
using QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategory;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Api.Controllers
{
    public partial class TrainingCategoriesController : QuickCodeBaseApiController
    {
        private readonly ITrainingCategoryService service;
        private readonly ILogger<TrainingCategoriesController> logger;
        private readonly IServiceProvider serviceProvider;
        public TrainingCategoriesController(ITrainingCategoryService service, IServiceProvider serviceProvider, ILogger<TrainingCategoriesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TrainingCategoryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "TrainingCategory", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "TrainingCategory") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainingCategoryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "TrainingCategory", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TrainingCategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TrainingCategoryDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "TrainingCategory") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, TrainingCategoryDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "TrainingCategory", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "TrainingCategory", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await service.GetAllAsync();
            if (HandleResponseError(response, logger, "TrainingCategory", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingCategoryId}/training-category-assignment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingCategoryAssignmentsForTrainingCategoriesAsync(int trainingCategoriesId)
        {
            var response = await service.GetTrainingCategoryAssignmentsForTrainingCategoriesAsync(trainingCategoriesId);
            if (HandleResponseError(response, logger, "TrainingCategory", $"TrainingCategoriesId: '{trainingCategoriesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{trainingCategoryId}/training-category-assignment/{trainingCategoryAssignmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTrainingCategoryAssignmentsForTrainingCategoriesDetailsAsync(int trainingCategoriesId, int trainingCategoryAssignmentsId)
        {
            var response = await service.GetTrainingCategoryAssignmentsForTrainingCategoriesDetailsAsync(trainingCategoriesId, trainingCategoryAssignmentsId);
            if (HandleResponseError(response, logger, "TrainingCategory", $"TrainingCategoriesId: '{trainingCategoriesId}', TrainingCategoryAssignmentsId: '{trainingCategoryAssignmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}