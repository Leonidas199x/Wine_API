using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public interface IDrinkerRepository
    {
        Task<IEnumerable<Drinker>> GetAll();

        Task<Drinker> Get(int drinkerId);

        Task<IEnumerable<Drinker>> GetByName(string name);

        Task<ValidationResult> Update(Drinker drinker);

        Task Delete(int drinkerId);

        Task<ValidationResult> Insert(Drinker drinker);
    }
}