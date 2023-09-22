using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Issue
{
    public interface IIssueRepository
    {
        Task<Issue> Get(int Id);

        Task<IEnumerable<Issue>> GetByWineId(int wineId);

        Task<ValidationResult> Insert(Issue issue);

        Task<ValidationResult> Update(Issue issue);
    }
}