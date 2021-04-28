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
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<CountryLookup>(
                "[dbo].[Country_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<Country>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<Country>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[Country_GetAll]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<Country>>>();
                pagingInfo.Data = await multi.ReadAsync<Country>();
            }

            return pagingInfo;
        }

        public async Task<Country> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Country>(
                "[dbo].[Country_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Country>> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryName", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Country>(
                "[dbo].[Country_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Country>> GetByIsoCode(string isoCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IsoCode", isoCode, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Country>(
                "[dbo].[Country_GetByIsoCode]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int countryId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

                using var connection = new SqlConnection(_connectionString);

                await connection.QueryAsync<Country>(
                    "[dbo].[Country_Delete]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);

                return new ValidationResult();
            }
            catch(SqlException ex)
            {
                return SqlExceptionHandler.HandleException(ex, "Country");
            }
        }

        public async Task<ValidationResult> Insert(Country country)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryName", country.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryNote", country.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsoCode", country.IsoCode, DbType.String, ParameterDirection.Input);

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

        public async Task<ValidationResult> Update(Country country)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", country.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryName", country.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryNote", country.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsoCode", country.IsoCode, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Country_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
    }
}
