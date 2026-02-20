namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Skill
    {
        public static class Query
        {
            private const string _prefix = "CandidateTrackingModule.Skill.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCandidate => ResourceKey("GetByCandidate.g.sql");
        }
    }
}