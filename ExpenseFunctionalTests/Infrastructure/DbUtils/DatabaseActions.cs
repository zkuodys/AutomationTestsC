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
                    $"INSERT INTO ReceiptEntities (Date, Title, CurrencyId, Status, IsTrash, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData.jpg', 1, 0, 1, N'4cef5297-989d-4300-a17f-94fdb0b7907c', 1); SELECT SCOPE_IDENTITY()");

            Debug.WriteLine($"Test data prepared, ReceiptEntity id = {receiptEntityId}");

            db.ExecuteSqlQuery(
                $"INSERT INTO FileEntities(id, Name, Hash, Viewable, UploadDate) values({receiptEntityId}, 'AutomatedTestData.jpg', '', 1, CONVERT(DATETIME, '2017-03-03 00:00:00', 102))");
        }

        public static void PopulateReceiptDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var receiptEntityId =
                db.ExecuteSqlQueryScalar(
                    $"INSERT INTO ReceiptEntities (Date, Title, CurrencyId, Status, IsTrash, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData.jpg', 1, 0, 0, N'4cef5297-989d-4300-a17f-94fdb0b7907c', 1); SELECT SCOPE_IDENTITY()");

            Debug.WriteLine($"Test data prepared, ReceiptEntity id = {receiptEntityId}");

            db.ExecuteSqlQuery(
                $"INSERT INTO FileEntities(id, Name, Hash, Viewable, UploadDate) values({receiptEntityId}, 'AutomatedTestData.jpg', '', 1, CONVERT(DATETIME, '2017-03-03 00:00:00', 102))");
        }

        public static void PopulateAwaitingApprovalDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var receiptEntityId =
                db.ExecuteSqlQueryScalar(
                    $"INSERT INTO ReceiptEntities (Date, Title, CurrencyId, Status, IsTrash, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData.jpg', 1, 2, 0, N'4cef5297-989d-4300-a17f-94fdb0b7907c', 1); SELECT SCOPE_IDENTITY()");

            Debug.WriteLine($"Test data prepared, ReceiptEntity id = {receiptEntityId}");

            db.ExecuteSqlQuery(
                $"INSERT INTO FileEntities(id, Name, Hash, Viewable, UploadDate) values({receiptEntityId}, 'AutomatedTestData.jpg', '', 1, CONVERT(DATETIME, '2017-03-03 00:00:00', 102))");
        }

        public static void PopulateApprovedDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var receiptEntityId =
                db.ExecuteSqlQueryScalar(
                    $"INSERT INTO ReceiptEntities (Date, Title, CurrencyId, Status, IsTrash, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData.jpg', 1, 3, 0, N'4cef5297-989d-4300-a17f-94fdb0b7907c', 1); SELECT SCOPE_IDENTITY()");

            Debug.WriteLine($"Test data prepared, ReceiptEntity id = {receiptEntityId}");

            db.ExecuteSqlQuery(
                $"INSERT INTO FileEntities(id, Name, Hash, Viewable, UploadDate) values({receiptEntityId}, 'AutomatedTestData.jpg', '', 1, CONVERT(DATETIME, '2017-03-03 00:00:00', 102))");
        }

        public static void PopulateExpenseDraftsDatabase()
        {
            DataBaseUtils db =
                new DataBaseUtils(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var receiptEntityId =
                db.ExecuteSqlQueryScalar(
                    $"INSERT INTO ReceiptEntities (Date, Title, CurrencyId, Status, IsTrash, OwnerId, IsNew) VALUES(CONVERT(DATETIME, '2017-03-03 00:00:00', 102), N'AutomatedTestData.jpg', 1, 1, 0, N'4cef5297-989d-4300-a17f-94fdb0b7907c', 1); SELECT SCOPE_IDENTITY()");

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
