using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingCategoryAssignment;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingCategoryAssignment
{
    public partial interface ITrainingCategoryAssignmentService
    {
        Task<Response<TrainingCategoryAssignmentDto>> InsertAsync(TrainingCategoryAssignmentDto request);
        Task<Response<bool>> DeleteAsync(TrainingCategoryAssignmentDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingCategoryAssignmentDto request);
        Task<Response<List<TrainingCategoryAssignmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingCategoryAssignmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int trainingCategoryAssignmentTrainingId, int? page, int? size);
    }
}