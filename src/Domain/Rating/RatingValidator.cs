using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public class RatingValidator : AbstractValidator<WineRating>
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingValidator(IRatingRepository ratingRepository) 
        {
            _ratingRepository = ratingRepository;

            RuleFor(x => x.Rating)
                .NotEmpty()
                .NotNull()
                .WithMessage("Rating is required")
                .LessThanOrEqualTo(10)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Rating must be between 0 and 10");

            RuleFor(x => x.WineId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Wine ID is required");

            RuleFor(x => x.Drinker.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Drinker ID is required");

            RuleFor(x => x.WineId)
                .MustAsync(async (rating, context, cancellation) =>
                {
                    return await RatingExists(rating)
                    .ConfigureAwait(false);
                })
                .WithMessage("A rating for the specified wine, with the specified drinker already exists");
        }

        private async Task<bool> RatingExists(WineRating rating)
        {
            var result = await _ratingRepository
                                    .GetByWineIdAndDrinkerId(rating.WineId, rating.Drinker.Id)
                                    .ConfigureAwait(false);

            return result != null;
        }
    }
}
