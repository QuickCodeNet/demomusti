using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategory;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategory
{
    public partial interface ITrainingCategoryService
    {
        Task<Response<TrainingCategoryDto>> InsertAsync(TrainingCategoryDto request);
        Task<Response<bool>> DeleteAsync(TrainingCategoryDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingCategoryDto request);
        Task<Response<List<TrainingCategoryDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingCategoryDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
        Task<Response<List<GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto>>> GetTrainingCategoryAssignmentsForTrainingCategoriesAsync(int trainingCategoriesId);
        Task<Response<GetTrainingCategoryAssignmentsForTrainingCategoriesResponseDto>> GetTrainingCategoryAssignmentsForTrainingCategoriesDetailsAsync(int trainingCategoriesId, int trainingCategoryAssignmentsId);
    }
}