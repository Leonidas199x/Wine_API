using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public interface IDrinkerRepository
    {
        Task<PagedList<IEnumerable<Drinker>>> GetAll(int page, int pageSize);

        Task<Drinker> Get(int drinkerId);

        Task<IEnumerable<Drinker>> GetByName(string name);

        Task<IEnumerable<Drinker>> GetLookup();

        Task<ValidationResult> Update(Drinker drinker);

        Task<ValidationResult> Delete(int drinkerId);

        Task<ValidationResult> Insert(Drinker drinker);
    }
}