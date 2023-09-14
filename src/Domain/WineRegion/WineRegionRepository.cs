using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
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

        public async Task<PagedList<IEnumerable<WineRegion>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<WineRegion>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[WineRegion_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<WineRegion>>>();

                var regions = multi.Read<WineRegion, Region.Region, Country, WineRegion>(AddRegion, splitOn: "ID");
                pagingInfo.Data = regions;
            }

            return pagingInfo;
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
            parameters.Add("@RegionId", wineRegion.Region.Id, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("@RegionId", wineRegion.Region.Id, DbType.Int32, ParameterDirection.Input);
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

        private WineRegion AddRegion(WineRegion wineRegion, Region.Region region, Country country)
        {
            if (wineRegion != null && region != null)
            {
                wineRegion.Region = region;
            }

            if (region != null && country != null) 
            {
                region.Country = country;
            }

            return wineRegion;
        }
    }
}
