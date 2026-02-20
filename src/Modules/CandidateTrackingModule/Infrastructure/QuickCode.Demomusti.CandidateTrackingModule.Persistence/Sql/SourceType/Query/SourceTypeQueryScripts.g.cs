namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SourceType
    {
        public static class Query
        {
            private const string _prefix = "CandidateTrackingModule.SourceType.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
            public static string GetCandidateSourcesForSourceTypes => ResourceKey("GetCandidateSourcesForSourceTypes.g.sql");
            public static string GetCandidateSourcesForSourceTypesDetails => ResourceKey("GetCandidateSourcesForSourceTypesDetails.g.sql");
        }
    }
}