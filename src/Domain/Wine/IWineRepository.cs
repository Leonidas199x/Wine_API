using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Wine
{
    public interface IWineRepository
    {
        Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize);

        Task<Wine> Get(int Id);

        Task<(ValidationResult, int)> Insert(WineCreate wine);

        Task<WineCreate> GetByDescription(string description);

        Task<ValidationResult> Update(WineUpdate wine);

        Task<ValidationResult> Delete(int id);
    }
}