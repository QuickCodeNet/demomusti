namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TrainingMaterial
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.TrainingMaterial.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByTraining => ResourceKey("GetByTraining.g.sql");
        }
    }
}