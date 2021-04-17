using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Producer
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetAll();

        Task<Producer> Get(int Id);

        Task<ValidationResult> Insert(Producer producer);

        Task<ValidationResult> Update(Producer producer);

        Task Delete(int id);


    }
}