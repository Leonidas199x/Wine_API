using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public class VineyardEstateRepository : IVineyardEstateRepository
    {
        private readonly string _connectionString;

        public VineyardEstateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<PagedList<IEnumerable<VineyardEstate>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<VineyardEstate>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                 "[dbo].[VineyardEstate_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<VineyardEstate>>>();
                pagingInfo.Data = await multi.ReadAsync<VineyardEstate>();
            }

            return pagingInfo;
        }

        public async Task<VineyardEstate> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VineyardEstateId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<VineyardEstate>(
                "[dbo].[VineyardEstate_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<VineyardEstate> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<VineyardEstate>(
                "[dbo].[VineyardEstate_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<VineyardEstateLookup>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<VineyardEstateLookup>(
                "[dbo].[VineyardEstate_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(VineyardEstate vineyardEstate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", vineyardEstate.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", vineyardEstate.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@Longitude", vineyardEstate.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Latitude", vineyardEstate.Latitude, DbType.Decimal, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[VineyardEstate_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(VineyardEstate vineyardEstate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VineyardEstateId", vineyardEstate.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@Name", vineyardEstate.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", vineyardEstate.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@Longitude", vineyardEstate.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Latitude", vineyardEstate.Latitude, DbType.Decimal, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[VineyardEstate_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task Delete(int vineyardEstateId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VineyardEstateId", vineyardEstateId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<VineyardEstate>(
                "[dbo].[VineyardEstate_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }
    }
}
