using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public interface IVineyardEstateRepository
    {
        Task<IEnumerable<VineyardEstate>> GetAll();

        Task<VineyardEstate> Get(int Id);

        Task<ValidationResult> Insert(VineyardEstate vineyardEstate);

        Task<ValidationResult> Update(VineyardEstate vineyardEstate);

        Task Delete(int vineyardEstateId);
    }
}