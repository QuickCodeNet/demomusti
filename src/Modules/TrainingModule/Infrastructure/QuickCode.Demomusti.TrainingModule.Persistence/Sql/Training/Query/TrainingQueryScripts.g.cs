namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Training
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.Training.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetByType => ResourceKey("GetByType.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            public static string GetEmployeeTrainingsForTraining => ResourceKey("GetEmployeeTrainingsForTraining.g.sql");
            public static string GetEmployeeTrainingsForTrainingDetails => ResourceKey("GetEmployeeTrainingsForTrainingDetails.g.sql");
            public static string GetTrainingMaterialsForTraining => ResourceKey("GetTrainingMaterialsForTraining.g.sql");
            public static string GetTrainingMaterialsForTrainingDetails => ResourceKey("GetTrainingMaterialsForTrainingDetails.g.sql");
            public static string GetTrainingSessionsForTraining => ResourceKey("GetTrainingSessionsForTraining.g.sql");
            public static string GetTrainingSessionsForTrainingDetails => ResourceKey("GetTrainingSessionsForTrainingDetails.g.sql");
            public static string GetTrainingCategoryAssignmentsForTraining => ResourceKey("GetTrainingCategoryAssignmentsForTraining.g.sql");
            public static string GetTrainingCategoryAssignmentsForTrainingDetails => ResourceKey("GetTrainingCategoryAssignmentsForTrainingDetails.g.sql");
        }
    }
}