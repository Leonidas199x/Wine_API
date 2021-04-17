using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public interface IVineyardEstateService
    {
        Task<IEnumerable<VineyardEstate>> GetAll();

        Task<VineyardEstate> Get(int vineyardEstateid);

        Task<ValidationResult> Insert(VineyardEstate vineyardEstate);

        Task<ValidationResult> Update(VineyardEstate vineyardEstate);

        Task Delete(int regionId);
    }
}