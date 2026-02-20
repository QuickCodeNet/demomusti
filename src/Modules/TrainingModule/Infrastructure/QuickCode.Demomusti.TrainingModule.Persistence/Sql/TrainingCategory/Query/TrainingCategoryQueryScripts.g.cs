namespace QuickCode.Demomusti.TrainingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TrainingCategory
    {
        public static class Query
        {
            private const string _prefix = "TrainingModule.TrainingCategory.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
            public static string GetTrainingCategoryAssignmentsForTrainingCategories => ResourceKey("GetTrainingCategoryAssignmentsForTrainingCategories.g.sql");
            public static string GetTrainingCategoryAssignmentsForTrainingCategoriesDetails => ResourceKey("GetTrainingCategoryAssignmentsForTrainingCategoriesDetails.g.sql");
        }
    }
}