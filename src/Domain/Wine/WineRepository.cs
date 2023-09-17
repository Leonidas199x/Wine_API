using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain.Rating;
using System.Collections.Generic;
using Domain.Grapes;
using Domain.Region;
using System.Linq;

namespace Domain.Wine
{
    public class WineRepository : IWineRepository
    {
        private readonly string _connectionString;
        private readonly IGrapeRepository _grapeRepository;
        private readonly IRegionRepository _regionRepository;

        public WineRepository(
            string connectionString, 
            IGrapeRepository grapeRepository, 
            IRegionRepository regionRepository)
        {
            _connectionString = connectionString;
            _grapeRepository = grapeRepository;
            _regionRepository = regionRepository;
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
                    wine.QualityControl = await multi.ReadFirstOrDefaultAsync<QualityControl.QualityControl>();
                    wine.VineyardEstate = await multi.ReadFirstOrDefaultAsync<VineyardEstate.VineyardEstate>();
                    wine.WineType = await multi.ReadFirstOrDefaultAsync<WineType.WineType>();
                    wine.ExclusiveRetailer = await multi.ReadFirstOrDefaultAsync<Retailer.Retailer>();
                    wine.Ratings = await multi.ReadAsync<WineRating>();
                    wine.Grapes = multi.Read<Grape, GrapeColour, Grape>(_grapeRepository.AddGrapeColour, splitOn: "ID");
                    wine.Prices = await multi.ReadAsync<WinePrice>();
                    wine.Issues = await multi.ReadAsync<Issue.Issue>();
                    wine.Receipts = await multi.ReadAsync<Receipt.Receipt>();
                }
            }

            return wine;
        }
    }
}
