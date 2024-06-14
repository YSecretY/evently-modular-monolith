namespace Evently.Modules.Events.Presentation.TicketTypes.Requests.UpdatePrice;

public sealed record UpdateTicketTypePriceRequest(
    Guid TicketTypeId,
    decimal Price
);