using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public interface IDrinkerService
    {
        Task<IEnumerable<Drinker>> GetAll();

        Task<Drinker> Get(int drinkerId);

        Task<ValidationResult> Insert(Drinker drinker);

        Task<ValidationResult> Update(Drinker drinker);

        Task<ValidationResult> Delete(int drinkerId);
    }
}