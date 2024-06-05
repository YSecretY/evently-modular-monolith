namespace Evently.Modules.Event.Presentation.Events;

public sealed record TicketTypeResponse(
    Guid Id,
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
);