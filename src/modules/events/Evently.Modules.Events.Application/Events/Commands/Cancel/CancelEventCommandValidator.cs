using FluentValidation;

namespace Evently.Modules.Events.Application.Events.Commands.Cancel;

internal sealed class CancelEventCommandValidator : AbstractValidator<CancelEventCommand>
{
    public CancelEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}