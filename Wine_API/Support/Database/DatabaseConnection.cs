using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Support
{
    public class DatabaseConnection
    {
        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

            }
        }

        static private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings[""];
        }
    }
}
