using QuickCode.Demomusti.Common.Nswag.Clients.CandidateTrackingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.CandidateTrackingModule
{
    public class QualificationData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public QualificationDto SelectedItem { get; set; }
        public List<QualificationDto> List { get; set; }
    }

    public static partial class QualificationExtensions
    {
        public static string GetKey(this QualificationDto dto)
        {
            return $"{dto.Id}";
        }
    }
}