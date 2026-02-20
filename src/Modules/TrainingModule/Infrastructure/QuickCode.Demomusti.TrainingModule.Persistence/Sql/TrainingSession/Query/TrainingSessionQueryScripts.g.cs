namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TrainingSession
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.TrainingSession.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByTraining => ResourceKey("GetByTraining.g.sql");
        }
    }
}