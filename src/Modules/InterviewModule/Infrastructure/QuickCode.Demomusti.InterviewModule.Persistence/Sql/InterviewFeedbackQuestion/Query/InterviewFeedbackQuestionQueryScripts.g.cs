namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class InterviewFeedbackQuestion
    {
        public static class Query
        {
            private const string _prefix = "InterviewModule.InterviewFeedbackQuestion.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
            public static string GetInterviewFeedbackAnswersForInterviewFeedbackQuestions => ResourceKey("GetInterviewFeedbackAnswersForInterviewFeedbackQuestions.g.sql");
            public static string GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsDetails => ResourceKey("GetInterviewFeedbackAnswersForInterviewFeedbackQuestionsDetails.g.sql");
        }
    }
}