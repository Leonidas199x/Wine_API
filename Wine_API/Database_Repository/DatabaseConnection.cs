using System;
using System.Data.SqlClient;
using System.Configuration;
using Database_Repository.Interfaces;

namespace Database_Repository
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SqlConnection OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                return connection;
            }
          
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["WineDatabase"].ConnectionString;
        }

    }
}
