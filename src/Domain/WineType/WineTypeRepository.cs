using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public class WineTypeRepository : IWineTypeRepository
    {
        private readonly string _connectionString;

        public WineTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<PagedList<IEnumerable<WineType>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<WineType>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[WineType_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<WineType>>>();
                pagingInfo.Data = await multi.ReadAsync<WineType>();
            }

            return pagingInfo;
        }

        public async Task<WineType> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineTypeId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<WineType>(
                "[dbo].[WineType_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<WineType> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<WineType>(
                "[dbo].[WineType_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<WineTypeLookup>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<WineTypeLookup>(
                "[dbo].[WineType_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineType wineType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", wineType.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", wineType.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[WineType_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(WineType wineType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineTypeId", wineType.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", wineType.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", wineType.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[WineType_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineTypeId", id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<WineType>(
                "[dbo].[WineType_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
        }
    }
}
