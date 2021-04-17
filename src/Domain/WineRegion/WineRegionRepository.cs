using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FluentValidation.Results;

namespace Domain.WineRegion
{
    public class WineRegionRepository : IWineRegionRepository
    {
        private readonly string _connectionString;

        public WineRegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<WineRegion>> GetAll()
        {
            var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<WineRegion>(
                "[dbo].[WineRegion_GetAll]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<WineRegion> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineRegionId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<WineRegion>(
                "[dbo].[WineRegion_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineRegion wineRegion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", wineRegion.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RegionId", wineRegion.RegionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CountryID", wineRegion.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[WineRegion_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(WineRegion wineRegion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", wineRegion.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", wineRegion.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RegionId", wineRegion.RegionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Note", wineRegion.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[WineRegion_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineRegionId", id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<WineRegion>(
                "[dbo].[WineRegion_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }
    }
}
