﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FluentValidation.Results;

namespace Domain.Grapes
{
    public class GrapeRepository : IGrapesRepository
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
    }
}