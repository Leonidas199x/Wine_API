using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Issue
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IValidator<Issue> _issueValidator;

        public IssueService(
            IIssueRepository issueRepository, 
            IValidator<Issue> issueValidator) 
        {
            _issueRepository = issueRepository;
            _issueValidator = issueValidator;
        }

        public async Task<Issue> Get(int issueId)
        {
            return await _issueRepository.Get(issueId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Issue>> GetByWineId(int wineId)
        {
            return await _issueRepository.GetByWineId(wineId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Issue issue)
        {
            var validationResult = _issueValidator.Validate(issue);
            if (!validationResult.IsValid) 
            {
                return validationResult;
            }

            return await _issueRepository.Update(issue).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Issue issue)
        {
            var validationResult = _issueValidator.Validate(issue);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _issueRepository.Insert(issue).ConfigureAwait(false);
        }
    }
}
