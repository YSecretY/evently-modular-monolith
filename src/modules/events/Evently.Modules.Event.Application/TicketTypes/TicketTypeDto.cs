namespace Evently.Modules.Event.Application.TicketTypes;

public sealed record TicketTypeDto(
    Guid Id,
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
);