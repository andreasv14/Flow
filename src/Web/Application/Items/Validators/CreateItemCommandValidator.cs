using Flow.WebAPI.Application.Items.Commands;
using FluentValidation;

namespace Flow.WebAPI.Application.Items.Validators;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name cannot be null or empty");
        RuleFor(x => x.ItemType).NotNull().NotEmpty().WithMessage("Item type cannot be null or empty");
    }
}