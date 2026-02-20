namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Candidate
    {
        public static class Query
        {
            private const string _prefix = "CandidateTrackingModule.Candidate.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            public static string GetRecentApplications => ResourceKey("GetRecentApplications.g.sql");
            public static string GetQualificationsForCandidates => ResourceKey("GetQualificationsForCandidates.g.sql");
            public static string GetQualificationsForCandidatesDetails => ResourceKey("GetQualificationsForCandidatesDetails.g.sql");
            public static string GetSkillsForCandidates => ResourceKey("GetSkillsForCandidates.g.sql");
            public static string GetSkillsForCandidatesDetails => ResourceKey("GetSkillsForCandidatesDetails.g.sql");
            public static string GetExperiencesForCandidates => ResourceKey("GetExperiencesForCandidates.g.sql");
            public static string GetExperiencesForCandidatesDetails => ResourceKey("GetExperiencesForCandidatesDetails.g.sql");
            public static string GetApplicationNotesForCandidates => ResourceKey("GetApplicationNotesForCandidates.g.sql");
            public static string GetApplicationNotesForCandidatesDetails => ResourceKey("GetApplicationNotesForCandidatesDetails.g.sql");
            public static string GetCandidateSourcesForCandidates => ResourceKey("GetCandidateSourcesForCandidates.g.sql");
            public static string GetCandidateSourcesForCandidatesDetails => ResourceKey("GetCandidateSourcesForCandidatesDetails.g.sql");
        }
    }
}