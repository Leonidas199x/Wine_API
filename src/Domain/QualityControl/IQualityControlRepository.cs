using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public interface IQualityControlRepository
    {
        Task<PagedList<IEnumerable<QualityControl>>> GetAll(int page, int pageSize);

        Task<QualityControl> Get(int Id);

        Task<IEnumerable<QualityControl>> GetByNameAndCountry(string name, int countryId);

        Task<IEnumerable<QualityControlLookup>> GetLookup();

        Task<ValidationResult> Insert(QualityControl qualityControl);

        Task<ValidationResult> Update(QualityControl qualityControl);

        Task<ValidationResult> Delete(int qualityControlId);

        QualityControl AddCountry(QualityControl qualityControl, Country country);
    }
}