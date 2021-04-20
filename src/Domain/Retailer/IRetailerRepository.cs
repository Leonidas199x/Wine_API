using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Retailer
{
    public interface IRetailerRepository
    {
        Task<IEnumerable<Retailer>> GetAll();

        Task<Retailer> Get(int Id);

        Task<Retailer> GetByName(string name);

        Task<ValidationResult> Insert(Retailer retailer);

        Task<ValidationResult> Update(Retailer retailer);

        Task<ValidationResult> Delete(int id);
    }
}