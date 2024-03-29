﻿using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public class DrinkerRepository : IDrinkerRepository
    {
        private readonly string _connectionString;

        public DrinkerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Drinker>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Drinker>(
                "[dbo].[Drinker_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<Drinker>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<Drinker>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[Drinker_GetAll]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<Drinker>>>();
                pagingInfo.Data = await multi.ReadAsync<Drinker>();
            }

            return pagingInfo;
        }

        public async Task<Drinker> Get(int drinkerId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DrinkerId", drinkerId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Drinker>(
                "[dbo].[Drinker_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Drinker>> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Drinker>(
                "[dbo].[Drinker_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Drinker drinker)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DrinkerId", drinker.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@Name", drinker.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Drinker_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int drinkerId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DrinkerId", drinkerId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync<Country>(
                "[dbo].[Drinker_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Insert(Drinker drinker)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", drinker.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Drinker_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
    }
}
