using MediatR;

namespace Evently.Modules.Event.Application.Events.Commands.Create;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    Guid CategoryId,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : IRequest<Guid>;