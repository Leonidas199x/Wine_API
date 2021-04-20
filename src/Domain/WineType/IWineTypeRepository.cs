using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public interface IWineTypeRepository
    {
        Task<IEnumerable<WineType>> GetAll();

        Task<WineType> Get(int Id);

        Task<WineType> GetByName(string name);

        Task<ValidationResult> Insert(WineType wineType);

        Task<ValidationResult> Update(WineType wineType);

        Task<ValidationResult> Delete(int id);
    }
}