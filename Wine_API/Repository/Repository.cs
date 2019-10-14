using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using DataContract.Country;

namespace DataRepository
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Country> GetCountries()
        {
            IEnumerable<Country> countries = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                countries = connection.Query<Country>("[dbo].[spGetAllCountries]");
            }

            return countries;
        }

        public IEnumerable<FullCountry> GetCountry(int countryId)
        {
            IEnumerable<FullCountry> country = null;

            var parameters = new DynamicParameters();
            parameters.Add("@intCountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                country = connection.Query<FullCountry>("[dbo].[spGetCountry]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }

            return country;
        }
    }
}
