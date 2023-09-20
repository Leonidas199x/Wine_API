using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Rating
{
    public interface IRatingRepository
    {
        Task<IEnumerable<WineRating>> GetByWineId(int wineId);

        Task<WineRating> GetByWineIdAndDrinkerId(int wineId, int drinkerId);

        Task<ValidationResult> Insert(WineRating rating);
    }
}