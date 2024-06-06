using Evently.Modules.Event.Domain.Events;

namespace Evently.Modules.Event.Application.Events;

public sealed record EventDto(
    Guid Id,
    string Title,
    string Description,
    string Location,
    Guid CategoryId,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc,
    EventStatus Status
);