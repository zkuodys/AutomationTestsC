using System.Configuration;
using System.Diagnostics;

namespace ExpenseFunctionalTests.Infrastructure.DbUtils
{
    public static class DatabaseAction
    {
        public static void TestDb()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var res = db.ExecuteSqlQuery($"select * from FileEntities");
        }

        public static void PopulateTrashboxDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var receiptEntityId =
                db.ExecuteSqlQueryScalar(
                    $"INSERT INTO ReceiptEntities (Date, Title, Currency, Status, Deleted, Comment, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData', 0, 0, 1, N'Comment', N'63902c24-2046-409d-bc8d-e2827c212c25', 1); SELECT SCOPE_IDENTITY()");

            Debug.WriteLine($"Test data prepared, ReceiptEntity id = {receiptEntityId}");

            db.ExecuteSqlQuery(
                $"INSERT INTO FileEntities(id, Name, Hash, Viewable, UploadDate) values({receiptEntityId}, 'AutomatedTestData.jpg', '', 1, CONVERT(DATETIME, '2017-03-03 00:00:00', 102))");
        }

        public static void CleanUpTrashboxDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            db.ExecuteSqlQuery($"delete from BinaryFileEntities where Id in (select Id from FileEntities where Name like '%AutomatedTestData%')");

            db.ExecuteSqlQuery($"delete from FileEntities where Name like '%AutomatedTestData%'");

            db.ExecuteSqlQuery($"delete from ReceiptEntities where Title like '%AutomatedTestData%'");
        }
    }
}
