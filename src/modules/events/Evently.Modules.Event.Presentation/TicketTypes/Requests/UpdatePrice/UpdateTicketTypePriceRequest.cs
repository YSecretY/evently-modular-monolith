namespace Evently.Modules.Event.Presentation.TicketTypes.Requests.UpdatePrice;

public sealed record UpdateTicketTypePriceRequest(
    Guid TicketTypeId,
    decimal Price
);