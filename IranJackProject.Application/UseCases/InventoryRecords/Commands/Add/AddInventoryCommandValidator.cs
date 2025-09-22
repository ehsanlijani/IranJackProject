using FluentValidation;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Add;

public class AddInventoryCommandValidator : AbstractValidator<AddInventoryCommand>
{
    public AddInventoryCommandValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Quantity cannot be negative.");
    }
}
