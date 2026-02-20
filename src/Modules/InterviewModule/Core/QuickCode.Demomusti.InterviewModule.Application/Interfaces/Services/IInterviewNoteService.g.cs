using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.InterviewModule.Application.Dtos.InterviewNote;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Application.Services.InterviewNote
{
    public partial interface IInterviewNoteService
    {
        Task<Response<InterviewNoteDto>> InsertAsync(InterviewNoteDto request);
        Task<Response<bool>> DeleteAsync(InterviewNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, InterviewNoteDto request);
        Task<Response<List<InterviewNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InterviewNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByInterviewResponseDto>>> GetByInterviewAsync(int interviewNoteInterviewId, int? page, int? size);
    }
}