using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public interface IVineyardEstateService
    {
        Task<PagedList<IEnumerable<VineyardEstate>>> GetAll(int page, int pageSize);

        Task<VineyardEstate> Get(int vineyardEstateid);

        Task<IEnumerable<VineyardEstateLookup>> GetLookup();

        Task<ValidationResult> Insert(VineyardEstate vineyardEstate);

        Task<ValidationResult> Update(VineyardEstate vineyardEstate);

        Task Delete(int regionId);
    }
}