namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Candidate
    {
        public static class Command
        {
            private const string _prefix = "CandidateTrackingModule.Candidate.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}