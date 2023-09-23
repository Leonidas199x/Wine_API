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

        public async Task<PagedList<IEnumerable<QualityControl>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<QualityControl>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[QualityControl_GetAll]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<QualityControl>>>();

                var qualityControls = multi.Read<QualityControl, Country, QualityControl>(AddCountry, splitOn: "ID");

                pagingInfo.Data = qualityControls;
            }

            return pagingInfo;
        }

        public async Task<QualityControl> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QualityControlId", Id, DbType.Int32, ParameterDirection.Input);

            QualityControl qualityControl;
            using var connection = new SqlConnection(_connectionString);
            using (var multi = await connection.QueryMultipleAsync(
               "[dbo].[QualityControl_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
               .ConfigureAwait(false))
            {
                qualityControl = await multi.ReadSingleOrDefaultAsync<QualityControl>();
                qualityControl.Country = await multi.ReadSingleOrDefaultAsync<Country>();
            }

            return qualityControl;
        }

        public async Task<IEnumerable<QualityControlLookup>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<QualityControlLookup>(
                "[dbo].[QualityControl_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<IEnumerable<QualityControl>> GetByNameAndCountry(string name, int countryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);
            parameters.Add("@CountryId", countryId, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[QualityControl_GetByNameAndCountryId]",
                 parameters,
                 commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                return multi.Read<QualityControl, Country, QualityControl>(AddCountry, splitOn: "ID");
            }
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

        public QualityControl AddCountry(QualityControl qualityControl, Country country)
        {
            if (qualityControl != null && country != null)
            {
                qualityControl.Country = country;
            }

            return qualityControl;
        }
    }
}
