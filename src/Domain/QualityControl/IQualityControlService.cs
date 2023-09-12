using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public interface IQualityControlService
    {
        Task<IEnumerable<QualityControl>> GetAll();

        Task<QualityControl> Get(int id);

        Task<ValidationResult> Insert(QualityControl qualityControl);

        Task<ValidationResult> Update(QualityControl qualityControl);

        Task<ValidationResult> Delete(int id);
    }
}