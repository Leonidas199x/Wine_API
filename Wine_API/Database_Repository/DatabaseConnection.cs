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

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        static private string GetConnectionString()
        {
            //return ConfigurationManager.AppSettings[];
            return string.Empty;
        }

    }
}
