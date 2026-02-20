namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Interview
    {
        public static class Command
        {
            private const string _prefix = "InterviewModule.Interview.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
            public static string AddFeedback => ResourceKey("AddFeedback.g.sql");
        }
    }
}