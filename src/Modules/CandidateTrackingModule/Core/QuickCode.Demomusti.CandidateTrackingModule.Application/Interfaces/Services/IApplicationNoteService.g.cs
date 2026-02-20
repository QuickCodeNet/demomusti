using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.CandidateTrackingModule.Application.Dtos.ApplicationNote;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Application.Services.ApplicationNote
{
    public partial interface IApplicationNoteService
    {
        Task<Response<ApplicationNoteDto>> InsertAsync(ApplicationNoteDto request);
        Task<Response<bool>> DeleteAsync(ApplicationNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, ApplicationNoteDto request);
        Task<Response<List<ApplicationNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ApplicationNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCandidateResponseDto>>> GetByCandidateAsync(int applicationNoteCandidateId, int? page, int? size);
    }
}