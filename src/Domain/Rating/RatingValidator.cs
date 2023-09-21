using Domain.Drinker;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public class RatingValidator : AbstractValidator<WineRating>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IDrinkerRepository _drinkerRepository;

        public RatingValidator(IRatingRepository ratingRepository, IDrinkerRepository drinkerRepository) 
        {
            _ratingRepository = ratingRepository;
            _drinkerRepository = drinkerRepository;

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
                    return await RatingExists(rating).ConfigureAwait(false);
                })
                .WithMessage("A rating for the specified wine, with the specified drinker already exists");

            RuleFor(x => x.Drinker.Id)
                .MustAsync(async (drinker, context, cancellation) =>
                {
                    return await DrinkerExists(drinker).ConfigureAwait(false);
                })
                .WithMessage("The specified drinker does not exists");
        }

        private async Task<bool> RatingExists(WineRating rating)
        {
            if (!rating.IsNew)
            {
                return true;
            }

            var result = await _ratingRepository
                                    .GetByWineIdAndDrinkerId(rating.WineId, rating.Drinker.Id)
                                    .ConfigureAwait(false);

            return result == null;
        }

        private async Task<bool> DrinkerExists(WineRating rating)
        {
            var result = await _drinkerRepository
                                    .Get(rating.Drinker.Id)
                                    .ConfigureAwait(false);

            return result != null;
        }
    }
}
