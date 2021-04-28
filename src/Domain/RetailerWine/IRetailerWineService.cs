using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RetailerWine
{
    public interface IRetailerWineService
    {
        Task<IEnumerable<RetailerWineLookup>> GetLookup();

        Task<RetailerWine> Get(int id);

        Task<PagedList<IEnumerable<RetailerWine>>> GetAll(int page, int pageSize);

        Task<IEnumerable<RetailerWine>> GetByName(string name);

        Task<ValidationResult> Delete(int id);

        Task<ValidationResult> Insert(RetailerWine retailerWine);

        Task<ValidationResult> Update(RetailerWine retailerWine);
    }
}