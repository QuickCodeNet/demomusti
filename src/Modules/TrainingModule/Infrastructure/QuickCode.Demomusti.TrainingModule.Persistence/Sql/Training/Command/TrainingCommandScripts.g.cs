namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Training
    {
        public static class Command
        {
            private const string _prefix = "TrainingModule.Training.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
        }
    }
}