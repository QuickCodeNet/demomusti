namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Interviewer
    {
        public static class Query
        {
            private const string _prefix = "InterviewModule.Interviewer.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetInterviewsForInterviewers => ResourceKey("GetInterviewsForInterviewers.g.sql");
            public static string GetInterviewsForInterviewersDetails => ResourceKey("GetInterviewsForInterviewersDetails.g.sql");
        }
    }
}