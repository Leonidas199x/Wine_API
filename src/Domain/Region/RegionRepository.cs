using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.Region
{
    public class RegionRepository : IRegionRepository
    {
        private readonly string _connectionString;

        public RegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<RegionLookup>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<RegionLookup>(
                "[dbo].[Region_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<Region>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<Region>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[Region_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<Region>>>();

                var regions = multi.Read<Region, Country, Region>(AddCountry, splitOn: "ID");
                pagingInfo.Data = regions;
            }

            return pagingInfo;
        }

        public async Task<Region> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RegionId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Region>(
                "[dbo].[Region_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Region>> GetByNameAndCountryId(string name, int countryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RegionName", name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Region>(
                "[dbo].[Region_GetByNameAndCountryId]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Region>> GetByIsoCode(string isoCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IsoCode", isoCode, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Region>(
                "[dbo].[Region_GetByIsoCode]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Region region)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RegionName", region.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RegionNote", region.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryID", region.Country.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Longitude", region.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Latitude", region.Latitude, DbType.Decimal, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Region_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(Region region)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RegionId", region.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@RegionName", region.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RegionNote", region.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryId", region.Country.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Longitude", region.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Latitude", region.Latitude, DbType.Decimal, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Region_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task Delete(int regionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RegionId", regionId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Region>(
                "[dbo].[Region_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        private Region AddCountry(Region region, Country country)
        {
            if (region != null && country != null)
            {
                region.Country = country;
            }

            return region;
        }
    }
}
