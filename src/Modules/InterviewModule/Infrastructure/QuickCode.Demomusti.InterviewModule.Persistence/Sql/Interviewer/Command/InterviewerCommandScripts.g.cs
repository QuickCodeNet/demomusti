namespace QuickCode.Demomusti.InterviewModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Interviewer
    {
        public static class Command
        {
            private const string _prefix = "InterviewModule.Interviewer.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}