using QuickCode.Demomusti.Common.Nswag.Clients.CandidateTrackingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.CandidateTrackingModule
{
    public class ApplicationNoteData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ApplicationNoteDto SelectedItem { get; set; }
        public List<ApplicationNoteDto> List { get; set; }
    }

    public static partial class ApplicationNoteExtensions
    {
        public static string GetKey(this ApplicationNoteDto dto)
        {
            return $"{dto.Id}";
        }
    }
}