using System.Collections.Generic;
using Database_Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;

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
                countries = connection.Query<Models.Country>("[dbo].[spGetAllCountries]");
            }

            return countries;
        }

        public IEnumerable<Models.FullCountry> GetCountry(int countryId)
        {
            IEnumerable<Models.FullCountry> country = null;

            var parameters = new DynamicParameters();
            parameters.Add("@intCountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                country = connection.Query<Models.FullCountry>("[dbo].[spGetCountry]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }

            return country;
        }
    }
}
