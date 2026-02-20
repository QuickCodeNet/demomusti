using QuickCode.Demomusti.Common.Nswag.Clients.CandidateTrackingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.CandidateTrackingModule
{
    public class CandidateSourceData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public CandidateSourceDto SelectedItem { get; set; }
        public List<CandidateSourceDto> List { get; set; }
    }

    public static partial class CandidateSourceExtensions
    {
        public static string GetKey(this CandidateSourceDto dto)
        {
            return $"{dto.Id}";
        }
    }
}