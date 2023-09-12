using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain.Rating;

namespace Domain.Wine
{
    public class WineRepository : IWineRepository
    {
        private readonly string _connectionString;

        public WineRepository(string connectionString)
        {
            _connectionString = connectionString;
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

                if(wine != null)
                {
                    wine.Ratings = await multi.ReadAsync<WineRating>();
                    wine.Grapes = await multi.ReadAsync<Grape>();
                    wine.Prices = await multi.ReadAsync<WinePrice>();
                    wine.Issues = await multi.ReadAsync<Issue.Issue>();
                    wine.Receipts = await multi.ReadAsync<Receipt.Receipt>();
                }
            }

            return wine;
        }
    }
}
