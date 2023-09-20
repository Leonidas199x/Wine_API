using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public interface IRatingService
    {
        Task<IEnumerable<WineRating>> GetByWineId(int wineId);
    }
}