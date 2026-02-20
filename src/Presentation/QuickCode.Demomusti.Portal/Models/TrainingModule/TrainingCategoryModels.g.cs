using QuickCode.Demomusti.Common.Nswag.Clients.TrainingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.TrainingModule
{
    public class TrainingCategoryData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TrainingCategoryDto SelectedItem { get; set; }
        public List<TrainingCategoryDto> List { get; set; }
    }

    public static partial class TrainingCategoryExtensions
    {
        public static string GetKey(this TrainingCategoryDto dto)
        {
            return $"{dto.Id}";
        }
    }
}