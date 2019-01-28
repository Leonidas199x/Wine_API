using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Database_Repository
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
            return ConfigurationManager.ConnectionStrings["WineDatabase"].ConnectionString;
        }

    }
}
