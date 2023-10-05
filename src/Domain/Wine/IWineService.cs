using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Wine
{
    public interface IWineService
    {
        Task<Wine> Get(int Id);

        Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize);

        Task<(ValidationResult, int)> Insert(WineCreate wine);
    }
}