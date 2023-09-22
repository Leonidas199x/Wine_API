using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Domain.Issue
{
    public class IssueRepository : IIssueRepository
    {
        private readonly string _connectionString;

        public IssueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Issue> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IssueId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Issue>(
                "[dbo].[Issue_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Issue>> GetByWineId(int wineId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", wineId, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Issue>(
                                        "[dbo].[Issue_GetByWineId]",
                                        commandType: CommandType.StoredProcedure)
                                    .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Issue issue)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", issue.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Date", issue.Date, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Quantity", issue.Quantity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Note", issue.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Issue_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(Issue issue)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WineId", issue.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Date", issue.Date, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Quantity", issue.Quantity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Note", issue.Note, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Issue_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
    }
}
