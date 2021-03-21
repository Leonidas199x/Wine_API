using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DataContract.Grape;

namespace Repository.Grapes
{
    public class GrapesRepository : IGrapesRepository
    {
        private readonly string _connectionString;

        public GrapesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Grape>> GetAll()
        {
            IEnumerable<Grape> grapes = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                grapes = await connection.QueryAsync<Grape>("[dbo].[Grape_GetAll]").ConfigureAwait(false);
            }

            return grapes;
        }

        public async Task<IEnumerable<GrapeLookup>> GetGrapeLookup()
        {
            IEnumerable<GrapeLookup> grapes = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                grapes = await connection.QueryAsync<GrapeLookup>("[dbo].[Grape_GetAll]").ConfigureAwait(false);
            }

            return grapes;
        }

        public async Task<IEnumerable<Grape>> Get(int grapeId)
        {
            IEnumerable<Grape> grape = null;

            var parameters = new DynamicParameters();
            parameters.Add("@GrapeId", grapeId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                grape = await connection.QueryAsync<Grape>(
                    "[dbo].[Grape_GetById]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return grape;
        }
    }
}
