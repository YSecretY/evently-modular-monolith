using FluentValidation;

namespace Evently.Modules.Events.Application.TicketTypes.Commands.UpdatePrice;

internal sealed class UpdateTicketTypePriceCommandValidator : AbstractValidator<UpdateTicketTypePriceCommand>
{
    public UpdateTicketTypePriceCommandValidator()
    {
        RuleFor(c => c.TicketTypeId).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
    }
}