using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingSession;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingSession
{
    public partial interface ITrainingSessionService
    {
        Task<Response<TrainingSessionDto>> InsertAsync(TrainingSessionDto request);
        Task<Response<bool>> DeleteAsync(TrainingSessionDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingSessionDto request);
        Task<Response<List<TrainingSessionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingSessionDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int trainingSessionTrainingId, int? page, int? size);
    }
}