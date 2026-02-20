using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.AuditLog;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.AuditLog
{
    public partial interface IAuditLogService
    {
        Task<Response<AuditLogDto>> InsertAsync(AuditLogDto request);
        Task<Response<bool>> DeleteAsync(AuditLogDto request);
        Task<Response<bool>> UpdateAsync(Guid id, AuditLogDto request);
        Task<Response<List<AuditLogDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AuditLogDto>> GetItemAsync(Guid id);
        Task<Response<bool>> DeleteItemAsync(Guid id);
        Task<Response<int>> TotalItemCountAsync();
    }
}