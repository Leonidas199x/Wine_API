using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public interface IQualityControlRepository
    {
        Task<IEnumerable<QualityControl>> GetAll();

        Task<QualityControl> Get(int Id);

        Task<IEnumerable<QualityControl>> GetByNameAndCountry(string name, int countryId);

        Task<ValidationResult> Insert(QualityControl qualityControl);

        Task<ValidationResult> Update(QualityControl qualityControl);

        Task<ValidationResult> Delete(int qualityControlId);
    }
}