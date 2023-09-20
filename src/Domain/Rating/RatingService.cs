using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository) 
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<WineRating>> GetByWineId(int wineId)
        {
            return await _ratingRepository.GetByWineId(wineId).ConfigureAwait(false);
        }
    }
}
