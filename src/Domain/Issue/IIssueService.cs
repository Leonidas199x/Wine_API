using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Issue
{
    public interface IIssueService
    {
        Task<Issue> Get(int issueId);

        Task<IEnumerable<Issue>> GetByWineId(int wineId);

        Task<ValidationResult> Update(Issue issue);

        Task<ValidationResult> Insert(Issue issue);

        Task Delete(int issueId);
    }
}