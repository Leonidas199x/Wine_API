using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FluentValidation.Results;

namespace Domain.Grapes
{
    public class GrapeRepository : IGrapeRepository
    {
        private readonly string _connectionString;

        public GrapeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Grape
        public async Task<PagedList<IEnumerable<Grape>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<Grape>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[Grape_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<Grape>>>();
                pagingInfo.Data = await multi.ReadAsync<Grape>();
            }

            return pagingInfo;
        }

        public async Task<Grape> Get(int grapeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeId", grapeId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Grape>(
                "[dbo].[Grape_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> InsertGrape(Grape grape)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeName", grape.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@GrapeNote", grape.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@GrapeColourId", grape.GrapeColourId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Grape_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<IEnumerable<Grape>> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeName", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Grape>(
                "[dbo].[Grape_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> UpdateGrape(Grape grape)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeId", grape.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@GrapeName", grape.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@GrapeColourId", grape.GrapeColourId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GrapeNote", grape.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Grape_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> DeleteGrape(int grapeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeID", grapeId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Country>(
                "[dbo].[Grape_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
        }
        #endregion

        #region Grape Colour
        public async Task<PagedList<IEnumerable<GrapeColour>>> GetAllColours(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<GrapeColour>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[GrapeColour_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<GrapeColour>>>();
                pagingInfo.Data = await multi.ReadAsync<GrapeColour>();
            }

            return pagingInfo;
        }

        public async Task<GrapeColour> GetGrapeColour(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeColourID", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<GrapeColour>(
                "[dbo].[GrapeColour_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<GrapeColour>> GetByColour(string colour)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeColour", colour, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<GrapeColour>(
                "[dbo].[GrapeColour_GetByColour]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeColour", grapeColour.Colour, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[GrapeColour_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task DeleteGrapeColour(int grapeColourId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeColourID", grapeColourId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Country>(
                "[dbo].[GrapeColour_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> UpdateGrapeColour(GrapeColour grapeColour)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeColourID", grapeColour.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@GrapeColour", grapeColour.Colour, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[GrapeColour_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
        #endregion

        #region Alternate Name

        #endregion
    }
}
