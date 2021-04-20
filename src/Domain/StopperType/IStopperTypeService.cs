using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.StopperType
{
    public interface IStopperTypeService
    {
        Task<IEnumerable<StopperType>> GetAll();

        Task<StopperType> Get(int id);

        Task<ValidationResult> Insert(StopperType stopperType);

        Task<ValidationResult> Update(StopperType stopperType);

        Task<ValidationResult> Delete(int id);
    }
}