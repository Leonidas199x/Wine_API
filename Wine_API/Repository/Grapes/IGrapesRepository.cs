using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Grape;

namespace Repository.Grapes
{
    public interface IGrapesRepository
    {
        Task<IEnumerable<GrapeLookup>> GetGrapeLookup();
    }
}
