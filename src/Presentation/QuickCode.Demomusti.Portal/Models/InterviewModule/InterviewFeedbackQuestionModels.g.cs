using QuickCode.Demomusti.Common.Nswag.Clients.InterviewModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.Demomusti.Portal.Helpers;

namespace QuickCode.Demomusti.Portal.Models.InterviewModule
{
    public class InterviewFeedbackQuestionData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public InterviewFeedbackQuestionDto SelectedItem { get; set; }
        public List<InterviewFeedbackQuestionDto> List { get; set; }
    }

    public static partial class InterviewFeedbackQuestionExtensions
    {
        public static string GetKey(this InterviewFeedbackQuestionDto dto)
        {
            return $"{dto.Id}";
        }
    }
}