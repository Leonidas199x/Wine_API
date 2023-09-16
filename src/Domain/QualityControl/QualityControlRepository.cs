using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public class QualityControlRepository : IQualityControlRepository
    {
        private readonly string _connectionString;

        public QualityControlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<QualityControl>> GetAll()
        {
            var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<QualityControl>(
                "[dbo].[QualityControl_GetAll]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<QualityControl> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QualityControlId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<QualityControl>(
                "[dbo].[QualityControl_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<QualityControl>> GetByNameAndCountry(string name, int countryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<QualityControl>(
                "[dbo].[QualityControl_GetByNameAndCountryId]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(QualityControl qualityControl)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", qualityControl.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", qualityControl.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryID", qualityControl.Country.Id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[QualityControl_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(QualityControl qualityControl)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QualityControlId", qualityControl.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@Name", qualityControl.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Note", qualityControl.Note, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryId", qualityControl.Country.Id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[QualityControl_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int qualityControlId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QualityControlId", qualityControlId, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<QualityControl>(
                "[dbo].[QualityControl_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
        }
    }
}
