using System.Collections.Generic;
using Database_Models;
using System.Data.SqlClient;
using Dapper;

namespace Database_Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Models.Country> GetCountries()
        {
            IEnumerable<Models.Country> countries = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                countries = connection.Query<Models.Country>("spGetAllCountries");
            }

            return countries;
        }
    }
}
