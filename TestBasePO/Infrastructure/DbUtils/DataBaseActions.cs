using System.Configuration;

namespace ExpenseFunctionalTests.Infrastructure.DbUtils
{
    public static class DatabaseAction
    {
        public static void CleanUpApprovedHours()
        {
            DataBaseUtils db = new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            db.ExecuteSqlQuery($"");
        }

    }
}
