using QuickCode.Demomusti.Common.Nswag.Clients.TrainingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.TrainingModule
{
    public class TrainingCategoryAssignmentData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TrainingCategoryAssignmentDto SelectedItem { get; set; }
        public List<TrainingCategoryAssignmentDto> List { get; set; }
    }

    public static partial class TrainingCategoryAssignmentExtensions
    {
        public static string GetKey(this TrainingCategoryAssignmentDto dto)
        {
            return $"{dto.Id}";
        }
    }
}