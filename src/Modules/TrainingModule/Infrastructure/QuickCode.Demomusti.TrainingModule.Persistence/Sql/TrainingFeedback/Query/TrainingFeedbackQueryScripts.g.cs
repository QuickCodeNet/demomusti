namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TrainingFeedback
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.TrainingFeedback.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByEmployeeTraining => ResourceKey("GetByEmployeeTraining.g.sql");
        }
    }
}