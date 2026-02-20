using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.EmployeeTraining;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.EmployeeTraining
{
    public partial interface IEmployeeTrainingService
    {
        Task<Response<EmployeeTrainingDto>> InsertAsync(EmployeeTrainingDto request);
        Task<Response<bool>> DeleteAsync(EmployeeTrainingDto request);
        Task<Response<bool>> UpdateAsync(int id, EmployeeTrainingDto request);
        Task<Response<List<EmployeeTrainingDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<EmployeeTrainingDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByEmployeeResponseDto>>> GetByEmployeeAsync(int employeeTrainingEmployeeId, int? page, int? size);
        Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int employeeTrainingTrainingId, int? page, int? size);
        Task<Response<List<GetTrainingFeedbacksForEmployeeTrainingsResponseDto>>> GetTrainingFeedbacksForEmployeeTrainingsAsync(int employeeTrainingsId);
        Task<Response<GetTrainingFeedbacksForEmployeeTrainingsResponseDto>> GetTrainingFeedbacksForEmployeeTrainingsDetailsAsync(int employeeTrainingsId, int trainingFeedbacksId);
    }
}