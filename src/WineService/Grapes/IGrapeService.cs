using DataContract.Grape;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineService.Grapes
{
    public interface IGrapeService
    {
        Task<IEnumerable<Grape>> Get(int grapeId);

        Task<IEnumerable<Grape>> GetAll();
    }
}
