using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingFeedback;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingFeedback
{
    public partial interface ITrainingFeedbackService
    {
        Task<Response<TrainingFeedbackDto>> InsertAsync(TrainingFeedbackDto request);
        Task<Response<bool>> DeleteAsync(TrainingFeedbackDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingFeedbackDto request);
        Task<Response<List<TrainingFeedbackDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingFeedbackDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByEmployeeTrainingResponseDto>>> GetByEmployeeTrainingAsync(int trainingFeedbackEmployeeTrainingId, int? page, int? size);
    }
}