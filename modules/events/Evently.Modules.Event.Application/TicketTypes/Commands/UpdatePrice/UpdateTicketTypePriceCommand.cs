using MediatR;

namespace Evently.Modules.Event.Application.TicketTypes.Commands.UpdatePrice;

public sealed record UpdateTicketTypePriceCommand(
    Guid TicketTypeId,
    decimal Price
) : IRequest;