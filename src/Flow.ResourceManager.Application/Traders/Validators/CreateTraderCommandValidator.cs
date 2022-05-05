using Flow.ResourceManager.Application.Traders.Commands;
using FluentValidation;

namespace Flow.ResourceManager.Application.Traders.Validators
{
    public class CreateTraderCommandValidator : AbstractValidator<CreateTraderCommand>
    {
        public CreateTraderCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
