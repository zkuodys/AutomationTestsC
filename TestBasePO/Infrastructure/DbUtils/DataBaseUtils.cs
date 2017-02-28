using System.Data;
using System.Data.SqlClient;

namespace ExpenseFunctionalTests.Infrastructure.DbUtils
{
    public class DataBaseUtils
    {
        private readonly string _connectionString;

        public DataBaseUtils(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteSqlQuery(string sqlStatement)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sqlStatement, sqlConnection))
            using (var dt = new DataTable())
            using (var ds = new DataSet())
            {
                sqlConnection.Open();
                var dr = cmd.ExecuteReader();
                dt.Load(dr);
                ds.Tables.Add(dt);

                return ds.Tables[0];
            }
        }

    }
}
