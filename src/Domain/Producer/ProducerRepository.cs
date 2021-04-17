﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FluentValidation.Results;

namespace Domain.Producer
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly string _connectionString;

        public ProducerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Producer>(
                "[dbo].[Producer_GetAll]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<Producer> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProducerId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Producer>(
                "[dbo].[Producer_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Producer producer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProducerName", producer.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@ProducerNote", producer.Note, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Producer_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(Producer producer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProducerId", producer.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ProducerName", producer.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@ProducerNote", producer.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Producer_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProducerId", id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Producer>(
                "[dbo].[Producer_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }
    }
}
