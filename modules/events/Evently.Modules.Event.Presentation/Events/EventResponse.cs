namespace Evently.Modules.Event.Presentation.Events;

public sealed record EventResponse(
    Guid Id,
    string Title,
    string Description,
    string Location,
    Guid CategoryId,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc,
    List<TicketTypeResponse> TicketTypes
);