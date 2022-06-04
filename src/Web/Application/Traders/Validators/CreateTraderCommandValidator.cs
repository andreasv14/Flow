using Flow.WebAPI.Application.Traders.Commands;
using FluentValidation;

namespace Flow.WebAPI.Application.Traders.Validators
{
    public class CreateTraderCommandValidator : AbstractValidator<CreateTraderCommand>
    {
        public CreateTraderCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
