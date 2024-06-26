using FluentValidation;

namespace Evently.Modules.Event.Application.Events.Commands.Create;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.StartsAtUtc).NotEmpty();
        RuleFor(c => c.EndsAtUtc)
            .Must((cmd, endsAtUtc) => endsAtUtc > cmd.StartsAtUtc)
            .When(c => c.EndsAtUtc.HasValue)
            .WithMessage("End date cannot be earlier than the start one.");
    }
}