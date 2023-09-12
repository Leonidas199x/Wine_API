using Dapper;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.RetailerWine
{
    public class RetailerWineRepository : IRetailerWineRepository
    {
        private readonly string _connectionString;

        public RetailerWineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<RetailerWineLookup>> GetLookup()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<RetailerWineLookup>(
                "[dbo].[RetailerWine_Lookup]",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<RetailerWine>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<RetailerWine>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[RetailerWine_GetAll]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<RetailerWine>>>();
                pagingInfo.Data = await multi.ReadAsync<RetailerWine>();
            }

            return pagingInfo;
        }

        public async Task<RetailerWine> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RetailerWineId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<RetailerWine>(
                "[dbo].[RetailerWine_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<RetailerWine>> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<RetailerWine>(
                "[dbo].[RetailerWine_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RetailerWineId", id, DbType.Int32, ParameterDirection.Input);

                using var connection = new SqlConnection(_connectionString);

                await connection.QueryAsync<RetailerWine>(
                    "[dbo].[RetailerWine_Delete]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);

                return new ValidationResult();
            }
            catch (SqlException ex)
            {
                return SqlExceptionHandler.HandleException(ex, "RetailerWine");
            }
        }

        public async Task<ValidationResult> Insert(RetailerWine retailerWine)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", retailerWine.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RetailerId", retailerWine.RetailerId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineId", retailerWine.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Description", retailerWine.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@Discontinued", retailerWine.Discontinued, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@RetailerTasteGuide", retailerWine.RetailerTasteGuide, DbType.String, ParameterDirection.Input);
            parameters.Add("@StopperTypeId", retailerWine.StopperTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineCode", retailerWine.WineCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@CustomerRating", retailerWine.CustomerRating, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@TastingNotes", retailerWine.TastingNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@StorageNotes", retailerWine.StorageNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@Range", retailerWine.WineId, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[RetailerWine_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(RetailerWine retailerWine)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RetailerWineId", retailerWine.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RetailerId", retailerWine.RetailerId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineId", retailerWine.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Description", retailerWine.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@Discontinued", retailerWine.Discontinued, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@RetailerTasteGuide", retailerWine.RetailerTasteGuide, DbType.String, ParameterDirection.Input);
            parameters.Add("@StopperTypeId", retailerWine.StopperTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineCode", retailerWine.WineCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@CustomerRating", retailerWine.CustomerRating, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@TastingNotes", retailerWine.TastingNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@StorageNotes", retailerWine.StorageNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@Range", retailerWine.WineId, DbType.String, ParameterDirection.Input);
            parameters.Add("@Name", retailerWine.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@RetailerId", retailerWine.RetailerId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineId", retailerWine.WineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Description", retailerWine.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@Discontinued", retailerWine.Discontinued, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@RetailerTasteGuide", retailerWine.RetailerTasteGuide, DbType.String, ParameterDirection.Input);
            parameters.Add("@StopperTypeId", retailerWine.StopperTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@WineCode", retailerWine.WineCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@CustomerRating", retailerWine.CustomerRating, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@TastingNotes", retailerWine.TastingNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@StorageNotes", retailerWine.StorageNotes, DbType.String, ParameterDirection.Input);
            parameters.Add("@Range", retailerWine.WineId, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[RetailerWine_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }
    }
}
