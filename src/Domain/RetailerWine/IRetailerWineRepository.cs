using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RetailerWine
{
    public interface IRetailerWineRepository
    {
        Task<IEnumerable<RetailerWineLookup>> GetLookup();

        Task<PagedList<IEnumerable<RetailerWine>>> GetAll(int page, int pageSize);

        Task<RetailerWine> Get(int Id);

        Task<IEnumerable<RetailerWine>> GetByName(string name);

        Task<ValidationResult> Delete(int id);

        Task<ValidationResult> Insert(RetailerWine retailerWine);

        Task<ValidationResult> Update(RetailerWine retailerWine);


    }
}