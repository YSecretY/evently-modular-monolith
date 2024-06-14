namespace Evently.Modules.Events.Application.TicketTypes;

public sealed record TicketTypeDto(
    Guid Id,
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
);