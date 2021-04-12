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

        public async Task<IEnumerable<Grape>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Grape>("[dbo].[Grape_GetAll]").ConfigureAwait(false);
        }

        public async Task<IEnumerable<GrapeLookup>> GetGrapeLookup()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<GrapeLookup>("[dbo].[Lookup_Grape]").ConfigureAwait(false);
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

        public async Task<IEnumerable<GrapeColour>> GetAllColours()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<GrapeColour>("[dbo].[GrapeColour_GetAll]").ConfigureAwait(false);
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
    }
}
