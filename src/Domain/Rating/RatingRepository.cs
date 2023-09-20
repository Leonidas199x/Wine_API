using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public class RatingRepository : IRatingRepository
    {
        private readonly string _connectionString;

        public RatingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<WineRating>> GetByWineId(int wineId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", wineId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            using (var multi = await connection.QueryMultipleAsync(
               "[dbo].[Rating_GetByWineId]",
                parameters,
                commandType: CommandType.StoredProcedure)
               .ConfigureAwait(false))
            {
                return multi.Read<WineRating, Drinker.Drinker, WineRating>(AddDrinker, splitOn: "ID");
            }
        }

        private WineRating AddDrinker(WineRating rating, Drinker.Drinker drinker)
        {
            if (rating != null && drinker != null)
            {
                rating.Drinker = drinker;
            }

            return rating;
        }
    }
}
