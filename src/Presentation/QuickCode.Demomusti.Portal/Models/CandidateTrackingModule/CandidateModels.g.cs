using QuickCode.Demomusti.Common.Nswag.Clients.CandidateTrackingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.CandidateTrackingModule
{
    public class CandidateData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public CandidateDto SelectedItem { get; set; }
        public List<CandidateDto> List { get; set; }
    }

    public static partial class CandidateExtensions
    {
        public static string GetKey(this CandidateDto dto)
        {
            return $"{dto.Id}";
        }

        public static List<string> GetImageColumnNames(this CandidateDto dto) => new()
        {
            "Avatar"
        };
    }
}