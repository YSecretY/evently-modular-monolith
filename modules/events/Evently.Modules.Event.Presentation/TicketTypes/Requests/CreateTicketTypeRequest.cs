namespace Evently.Modules.Event.Presentation.TicketTypes.Requests;

public record CreateTicketTypeRequest(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
);