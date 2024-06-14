using FluentValidation;

namespace Evently.Modules.Events.Application.Events.Commands.Publish_;

internal sealed class PublishEventCommandValidator : AbstractValidator<PublishEventCommand>
{
    public PublishEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}