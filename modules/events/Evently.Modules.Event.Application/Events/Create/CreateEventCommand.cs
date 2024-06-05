using MediatR;

namespace Evently.Modules.Event.Application.Events.Create;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    Guid CategoryId,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : IRequest<Guid>;