using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IValidator<WineRating> _ratingValidator;

        public RatingService(IRatingRepository ratingRepository, IValidator<WineRating> ratingValidator) 
        {
            _ratingRepository = ratingRepository;
            _ratingValidator = ratingValidator;
        }

        public async Task<IEnumerable<WineRating>> GetByWineId(int wineId)
        {
            return await _ratingRepository.GetByWineId(wineId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineRating rating)
        {
            var validationResult = await _ratingValidator
                                            .ValidateAsync(rating)
                                            .ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _ratingRepository.Insert(rating).ConfigureAwait(false);
        }
    }
}
