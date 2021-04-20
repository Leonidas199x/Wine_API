using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public interface IWineTypeService
    {
        Task<IEnumerable<WineType>> GetAll();

        Task<WineType> Get(int id);

        Task<ValidationResult> Insert(WineType wineType);

        Task<ValidationResult> Update(WineType wineType);

        Task<ValidationResult> Delete(int id);
    }
}