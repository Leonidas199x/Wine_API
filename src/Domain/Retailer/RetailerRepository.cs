using Dapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.Retailer
{
    public class RetailerRepository : IRetailerRepository
    {
        private readonly string _connectionString;

        public RetailerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<PagedList<IEnumerable<Retailer>>> GetAll(int page, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

            var connection = new SqlConnection(_connectionString);

            PagedList<IEnumerable<Retailer>> pagingInfo;

            using (var multi = await connection.QueryMultipleAsync(
                "[dbo].[Retailer_GetAll]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
            {
                pagingInfo = await multi.ReadSingleOrDefaultAsync<PagedList<IEnumerable<Retailer>>>();
                pagingInfo.Data = await multi.ReadAsync<Retailer>();
            }

            return pagingInfo;
        }

        public async Task<Retailer> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RetailerId", Id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Retailer>(
                "[dbo].[Retailer_GetById]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<Retailer> GetByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, DbType.String, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            return await connection.QuerySingleOrDefaultAsync<Retailer>(
                "[dbo].[Retailer_GetByName]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Retailer retailer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", retailer.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@MinimumPurchaseQuantity", retailer.MinimumPurchaseQuantity, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@IncrementQuantity", retailer.IncrementQuantity, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@GenericDiscountPercentage", retailer.GenericDiscountPercentage, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@GenericDiscountName", retailer.GenericDiscountName, DbType.String, ParameterDirection.Input);
            parameters.Add("@WebsiteUrl", retailer.WebsiteUrl, DbType.String, ParameterDirection.Input);
            parameters.Add("@WebsiteRating", retailer.WebsiteRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@OrderRating", retailer.OrderRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@DeliveryRating", retailer.DeliveryRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@MaxCustomerRating", retailer.MaxCustomerRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@Note", retailer.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Retailer_Insert]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Update(Retailer retailer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RetailerId", retailer.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", retailer.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@MinimumPurchaseQuantity", retailer.MinimumPurchaseQuantity, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@IncrementQuantity", retailer.IncrementQuantity, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@GenericDiscountPercentage", retailer.GenericDiscountPercentage, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@GenericDiscountName", retailer.GenericDiscountName, DbType.String, ParameterDirection.Input);
            parameters.Add("@WebsiteUrl", retailer.WebsiteUrl, DbType.String, ParameterDirection.Input);
            parameters.Add("@WebsiteRating", retailer.WebsiteRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@OrderRating", retailer.OrderRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@DeliveryRating", retailer.DeliveryRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@MaxCustomerRating", retailer.MaxCustomerRating, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@Note", retailer.Name, DbType.String, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(
                    "[dbo].[Retailer_Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RetailerId", id, DbType.Int32, ParameterDirection.Input);

            using var connection = new SqlConnection(_connectionString);

            await connection.QueryAsync<Retailer>(
                "[dbo].[Retailer_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

            return new ValidationResult();
        }
    }
}
