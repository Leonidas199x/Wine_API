using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<GrapeLookup>> GetGrapeLookup()
        {
            IEnumerable<GrapeLookup> grapes = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                grapes = await connection.QueryAsync<GrapeLookup>("[dbo].[GetAllGrapes]").ConfigureAwait(false);
            }

            return grapes;
        }
    }
}
