using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Grapes;
using Domain.Region;
using System.Linq;
using Domain.QualityControl;
using FluentValidation.Results;

namespace Domain.Wine
{
    public class WineRepository : IWineRepository
    {
        private readonly string _connectionString;
        private readonly IGrapeRepository _grapeRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IQualityControlRepository _qualityControlRepository;

        public WineRepository(
            string connectionString,
            IGrapeRepository grapeRepository,
            IRegionRepository regionRepository,
            IQualityControlRepository qualityControlRepository)
        {
            _connectionString = connectionString;
            _grapeRepository = grapeRepository;
            _regionRepository = regionRepository;
            _qualityControlRepository = qualityControlRepository;
        }

        public async Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<WineHeader>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                 "[dbo].[Wine_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<WineHeader>>>();
                pagingInfo.Data = await multi.ReadAsync<WineHeader>();
            }

            return pagingInfo;
        }

        public async Task<Wine> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", Id, DbType.Int32, ParameterDirection.Input);
            Wine wine;

            using var connection = new SqlConnection(_connectionString);

            using(var multi = await connection.QueryMultipleAsync(
                "[dbo].[Wine_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                wine = await multi.ReadSingleOrDefaultAsync<Wine>();

                if (wine != null)
                {
                    wine.Producer = await multi.ReadFirstOrDefaultAsync<Producer.Producer>();
                    wine.Region = multi.Read<Region.Region, Country, Region.Region>(_regionRepository.AddCountry, splitOn: "ID").FirstOrDefault();
                    wine.QualityControl = multi.Read<QualityControl.QualityControl, Country, QualityControl.QualityControl>(_qualityControlRepository.AddCountry, splitOn: "ID").FirstOrDefault();
                    wine.VineyardEstate = await multi.ReadFirstOrDefaultAsync<VineyardEstate.VineyardEstate>();
                    wine.WineType = await multi.ReadFirstOrDefaultAsync<WineType.WineType>();
                    wine.ExclusiveRetailer = await multi.ReadFirstOrDefaultAsync<Retailer.Retailer>();
                    wine.Ratings = multi.Read<Rating.WineRating, Drinker.Drinker, Rating.WineRating>(AddDrinker, splitOn: "ID");
                    wine.Grapes = multi.Read<Grape, Grapes.GrapeColour, Grape>(_grapeRepository.AddGrapeColour, splitOn: "ID");
                    wine.Prices = await multi.ReadAsync<WinePrice>();
                    wine.Issues = await multi.ReadAsync<Issue.Issue>();
                    wine.Receipts = await multi.ReadAsync<Receipt.Receipt>();
                }
            }

            return wine;
        }

        public async Task<(ValidationResult, int)> Insert(WineCreate wine)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Description", wine.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@Importer", wine.Importer, DbType.String, ParameterDirection.Input);
            parameters.Add("@Abv", wine.Abv, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@RegionId", wine.RegionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ProducerId", wine.ProducerId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@QualityControlId", wine.QualityControlId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@VineyardEstateId", wine.VineyardEstateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineTypeId", wine.WineTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@InventoryLevel", wine.InventoryLevel, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ExclusiveToRetailerId", wine.ExclusiveToRetailerId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Vintage", wine.Vintage, DbType.Int32, ParameterDirection.Input);

            int wineId;
            using (var connection = new SqlConnection(_connectionString))
            {
                wineId = await connection.QuerySingleOrDefaultAsync<int>(
                    "[dbo].[Wine_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return (new ValidationResult(), wineId);
        }

        public async Task<WineCreate> GetByDescription(string description)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Description", description, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<WineCreate>(
                "[dbo].[Wine_GetByDescription]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        private Rating.WineRating AddDrinker(Rating.WineRating rating, Drinker.Drinker drinker)
        {
            if (rating != null && drinker != null)
            {
                rating.Drinker = drinker;
            }

            return rating;
        }
    }
}
