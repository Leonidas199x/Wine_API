using FluentValidation;

namespace Domain.Issue
{
    public class IssueValidator : AbstractValidator<Issue>
    {
        public IssueValidator() 
        {
            RuleFor(x => x.WineId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Wine ID is required.");

            RuleFor(x => x.Note)
                .NotEmpty()
                .NotNull()
                .WithMessage("Note is required.");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantity is required.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .NotNull()
                .WithMessage("Date is required.");
        }
    }
}
