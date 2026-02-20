using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.Training;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.Training
{
    public partial interface ITrainingService
    {
        Task<Response<TrainingDto>> InsertAsync(TrainingDto request);
        Task<Response<bool>> DeleteAsync(TrainingDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingDto request);
        Task<Response<List<TrainingDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool trainingIsActive, int? page, int? size);
        Task<Response<List<GetByTypeResponseDto>>> GetByTypeAsync(TrainingType trainingTrainingType, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(TrainingStatus trainingStatus, int? page, int? size);
        Task<Response<List<GetEmployeeTrainingsForTrainingResponseDto>>> GetEmployeeTrainingsForTrainingAsync(int trainingId);
        Task<Response<GetEmployeeTrainingsForTrainingResponseDto>> GetEmployeeTrainingsForTrainingDetailsAsync(int trainingId, int employeeTrainingsId);
        Task<Response<List<GetTrainingMaterialsForTrainingResponseDto>>> GetTrainingMaterialsForTrainingAsync(int trainingId);
        Task<Response<GetTrainingMaterialsForTrainingResponseDto>> GetTrainingMaterialsForTrainingDetailsAsync(int trainingId, int trainingMaterialsId);
        Task<Response<List<GetTrainingSessionsForTrainingResponseDto>>> GetTrainingSessionsForTrainingAsync(int trainingId);
        Task<Response<GetTrainingSessionsForTrainingResponseDto>> GetTrainingSessionsForTrainingDetailsAsync(int trainingId, int trainingSessionsId);
        Task<Response<List<GetTrainingCategoryAssignmentsForTrainingResponseDto>>> GetTrainingCategoryAssignmentsForTrainingAsync(int trainingId);
        Task<Response<GetTrainingCategoryAssignmentsForTrainingResponseDto>> GetTrainingCategoryAssignmentsForTrainingDetailsAsync(int trainingId, int trainingCategoryAssignmentsId);
        Task<Response<int>> UpdateStatusAsync(int trainingId, UpdateStatusRequestDto updateRequest);
    }
}