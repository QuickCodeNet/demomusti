using QuickCode.Demomusti.Common.Nswag.Clients.InterviewModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.InterviewModule
{
    public class InterviewerData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public InterviewerDto SelectedItem { get; set; }
        public List<InterviewerDto> List { get; set; }
    }

    public static partial class InterviewerExtensions
    {
        public static string GetKey(this InterviewerDto dto)
        {
            return $"{dto.Id}";
        }

        public static List<string> GetImageColumnNames(this InterviewerDto dto) => new()
        {
            "Avatar"
        };
    }
}