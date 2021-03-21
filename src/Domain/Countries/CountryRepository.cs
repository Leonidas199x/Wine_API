using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Domain.Countries
{
    public class CountryRepository : ICountryRepository
    {
        private readonly string _connectionString;

        public CountryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CountryLookup>> GetCountryLookup()
        {
            IEnumerable<CountryLookup> countries = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                countries = await connection.QueryAsync<CountryLookup>("[dbo].[Lookup_Country]").ConfigureAwait(false);
            }

            return countries;
        }

        public async Task<IEnumerable<Country>> Get(int countryId)
        {
            IEnumerable<Country> country = null;

            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                country = await connection.QueryAsync<Country>(
                    "[dbo].[Country_GetById]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return country;
        }

        public async Task<bool> Delete(int countryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync<Country>(
                    "[dbo].[Country_Delete]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return true;
        }

        public async Task<ValidationResult> Insert(Country country)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryName", country.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryNote", country.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Country_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
    }
}
