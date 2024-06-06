namespace Evently.Modules.Event.Presentation.TicketTypes.Requests.Create;

public record CreateTicketTypeRequest(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
);