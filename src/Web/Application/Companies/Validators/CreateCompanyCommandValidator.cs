using Flow.WebAPI.Application.Companies.Commands;
using FluentValidation;

namespace Flow.WebAPI.Application.Companies.Validators
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name cannot be null or empty");
        }
    }
}
