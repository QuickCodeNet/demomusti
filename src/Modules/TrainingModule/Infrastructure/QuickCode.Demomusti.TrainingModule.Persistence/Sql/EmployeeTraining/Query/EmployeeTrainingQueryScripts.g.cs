namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class EmployeeTraining
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.EmployeeTraining.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByEmployee => ResourceKey("GetByEmployee.g.sql");
            public static string GetByTraining => ResourceKey("GetByTraining.g.sql");
            public static string GetTrainingFeedbacksForEmployeeTrainings => ResourceKey("GetTrainingFeedbacksForEmployeeTrainings.g.sql");
            public static string GetTrainingFeedbacksForEmployeeTrainingsDetails => ResourceKey("GetTrainingFeedbacksForEmployeeTrainingsDetails.g.sql");
        }
    }
}