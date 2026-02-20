namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class InterviewSchedule
    {
        public static class Query
        {
            private const string _prefix = "InterviewModule.InterviewSchedule.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByInterview => ResourceKey("GetByInterview.g.sql");
        }
    }
}