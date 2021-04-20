using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.StopperType
{
    public class StopperTypeRepository : IStopperTypeRepository
    {
        private readonly string _connectionString;

        public StopperTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<StopperType>> GetAll()
        {
            var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<StopperType>(
                "[dbo].[StopperType_GetAll]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<StopperType> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StopperTypeId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<StopperType>(
                "[dbo].[StopperType_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<StopperType> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<StopperType>(
                "[dbo].[StopperType_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(StopperType stopperType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", stopperType.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[StopperType_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(StopperType stopperType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StopperTypeId", stopperType.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@Name", stopperType.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[StopperType_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StopperTypeId", id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<StopperType>(
                "[dbo].[StopperType_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
        }
    }
}
