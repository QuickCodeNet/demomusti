namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Interview
    {
        public static class Query
        {
            private const string _prefix = "InterviewModule.Interview.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCandidate => ResourceKey("GetByCandidate.g.sql");
            public static string GetByInterviewer => ResourceKey("GetByInterviewer.g.sql");
            public static string GetScheduled => ResourceKey("GetScheduled.g.sql");
            public static string GetCompleted => ResourceKey("GetCompleted.g.sql");
            public static string GetInterviewFeedbackAnswersForInterviews => ResourceKey("GetInterviewFeedbackAnswersForInterviews.g.sql");
            public static string GetInterviewFeedbackAnswersForInterviewsDetails => ResourceKey("GetInterviewFeedbackAnswersForInterviewsDetails.g.sql");
            public static string GetInterviewSchedulesForInterviews => ResourceKey("GetInterviewSchedulesForInterviews.g.sql");
            public static string GetInterviewSchedulesForInterviewsDetails => ResourceKey("GetInterviewSchedulesForInterviewsDetails.g.sql");
            public static string GetInterviewNotesForInterviews => ResourceKey("GetInterviewNotesForInterviews.g.sql");
            public static string GetInterviewNotesForInterviewsDetails => ResourceKey("GetInterviewNotesForInterviewsDetails.g.sql");
        }
    }
}