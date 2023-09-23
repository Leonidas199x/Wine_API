using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public interface IWineTypeRepository
    {
        Task<PagedList<IEnumerable<WineType>>> GetAll(int page, int pageSize);

        Task<WineType> Get(int Id);

        Task<WineType> GetByName(string name);

        Task<IEnumerable<WineTypeLookup>> GetLookup();

        Task<ValidationResult> Insert(WineType wineType);

        Task<ValidationResult> Update(WineType wineType);

        Task<ValidationResult> Delete(int id);
    }
}