using QuickCode.Demomusti.Common.Nswag.Clients.TrainingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.TrainingModule
{
    public class TrainingSessionData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TrainingSessionDto SelectedItem { get; set; }
        public List<TrainingSessionDto> List { get; set; }
    }

    public static partial class TrainingSessionExtensions
    {
        public static string GetKey(this TrainingSessionDto dto)
        {
            return $"{dto.Id}";
        }
    }
}