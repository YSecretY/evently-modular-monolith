using FluentValidation;

namespace Evently.Modules.Event.Application.Events.Commands.Publish_;

public class PublishEventCommandValidator : AbstractValidator<PublishEventCommand>
{
    public PublishEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}