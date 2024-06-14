using FluentValidation;

namespace Evently.Modules.Events.Application.TicketTypes.Commands.Create;

internal sealed class CreateTicketTypeCommandValidator : AbstractValidator<CreateTicketTypeCommand>
{
    public CreateTicketTypeCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
        RuleFor(c => c.Currency).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(0);
    }
}