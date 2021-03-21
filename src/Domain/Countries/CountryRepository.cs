﻿using System.Collections.Generic;
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
                "[dbo].[Lookup_Country]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<Country> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleAsync<Country>(
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

        public async Task Delete(int countryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Country>(
                "[dbo].[Country_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
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
