using FluentValidation;

namespace Evently.Modules.Event.Application.Events.Commands.Cancel;

public class CancelEventCommandValidator : AbstractValidator<CancelEventCommand>
{
    public CancelEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}