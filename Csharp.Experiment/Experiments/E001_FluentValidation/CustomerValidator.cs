using FluentValidation;

namespace Csharp.Experiment.Experiments.E001_FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Please specify a last name.");
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name.");
        }
    }
}