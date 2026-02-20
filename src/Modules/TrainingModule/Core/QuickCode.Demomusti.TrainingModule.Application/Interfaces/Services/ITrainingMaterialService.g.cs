using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.TrainingModule.Application.Dtos.TrainingMaterial;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Application.Services.TrainingMaterial
{
    public partial interface ITrainingMaterialService
    {
        Task<Response<TrainingMaterialDto>> InsertAsync(TrainingMaterialDto request);
        Task<Response<bool>> DeleteAsync(TrainingMaterialDto request);
        Task<Response<bool>> UpdateAsync(int id, TrainingMaterialDto request);
        Task<Response<List<TrainingMaterialDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TrainingMaterialDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByTrainingResponseDto>>> GetByTrainingAsync(int trainingMaterialTrainingId, int? page, int? size);
    }
}