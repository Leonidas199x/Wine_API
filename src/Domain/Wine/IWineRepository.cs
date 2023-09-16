using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Wine
{
    public interface IWineRepository
    {
        Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize);

        Task<Wine> Get(int Id);
    }
}