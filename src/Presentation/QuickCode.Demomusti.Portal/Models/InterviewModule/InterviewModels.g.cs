using QuickCode.Demomusti.Common.Nswag.Clients.InterviewModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.InterviewModule
{
    public class InterviewData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public InterviewDto SelectedItem { get; set; }
        public List<InterviewDto> List { get; set; }
    }

    public static partial class InterviewExtensions
    {
        public static string GetKey(this InterviewDto dto)
        {
            return $"{dto.Id}";
        }
    }
}