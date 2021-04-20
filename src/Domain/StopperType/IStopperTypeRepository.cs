using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.StopperType
{
    public interface IStopperTypeRepository
    {
        Task<IEnumerable<StopperType>> GetAll();

        Task<StopperType> Get(int Id);

        Task<StopperType> GetByName(string name);

        Task<ValidationResult> Insert(StopperType stopperType);

        Task<ValidationResult> Update(StopperType stopperType);

        Task<ValidationResult> Delete(int id);
    }
}