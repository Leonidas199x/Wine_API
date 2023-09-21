using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using FluentValidation.Results;

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

        public async Task<WineRating> Get(int ratingId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", ratingId, DbType.Int32, ParameterDirection.Input);

            WineRating rating;
            using var connection = new SqlConnection(_connectionString);
            using (var multi = await connection.QueryMultipleAsync(
               "[dbo].[Rating_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
               .ConfigureAwait(false))
            {
                rating = await multi.ReadSingleOrDefaultAsync<WineRating>();
                rating.Drinker = await multi.ReadSingleOrDefaultAsync<Drinker.Drinker>();
            }

            return rating;

        }

        public async Task<WineRating> GetByWineIdAndDrinkerId(int wineId, int drinkerId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", wineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DrinkerId", drinkerId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<WineRating>(
                "[dbo].[Rating_GetByWineIdAndDrinkerId]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineRating rating)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DrinkerId", rating.Drinker.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineId", rating.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rating", rating.Rating, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Note", rating.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Rating_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(WineRating rating)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", rating.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DrinkerId", rating.Drinker.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineId", rating.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rating", rating.Rating, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Note", rating.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Rating_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int ratingId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", ratingId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<WineRating>(
                "[dbo].[Rating_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
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
