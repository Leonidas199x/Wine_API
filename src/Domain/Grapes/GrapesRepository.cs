using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Domain.Grapes
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
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Grape>("[dbo].[Grape_GetAll]").ConfigureAwait(false);
        }

        public async Task<IEnumerable<GrapeLookup>> GetGrapeLookup()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<GrapeLookup>("[dbo].[Lookup_Grape]").ConfigureAwait(false);
        }

        public async Task<IEnumerable<Grape>> Get(int grapeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrapeId", grapeId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Grape>(
                "[dbo].[Grape_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }
    }
}
