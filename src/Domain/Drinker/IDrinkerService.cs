using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public interface IDrinkerService
    {
        Task<PagedList<IEnumerable<Drinker>>> GetAll(int page, int pageSize);

        Task<Drinker> Get(int drinkerId);

        Task<IEnumerable<Drinker>> GetLookup();

        Task<ValidationResult> Insert(Drinker drinker);

        Task<ValidationResult> Update(Drinker drinker);

        Task<ValidationResult> Delete(int drinkerId);
    }
}