using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Producer
{
    public interface IProducerRepository
    {
        Task<PagedList<IEnumerable<Producer>>> GetAll(int page, int pageSize);

        Task<Producer> Get(int Id);

        Task<ValidationResult> Insert(Producer producer);

        Task<ValidationResult> Update(Producer producer);

        Task Delete(int id);


    }
}