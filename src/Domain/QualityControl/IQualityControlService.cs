using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public interface IQualityControlService
    {
        Task<PagedList<IEnumerable<QualityControl>>> GetAll(int page, int pageSize);

        Task<QualityControl> Get(int id);

        Task<IEnumerable<QualityControlLookup>> GetLookup();

        Task<ValidationResult> Insert(QualityControl qualityControl);

        Task<ValidationResult> Update(QualityControl qualityControl);

        Task<ValidationResult> Delete(int id);
    }
}