using MediatR;

namespace Evently.Modules.Events.Application.TicketTypes.Commands.UpdatePrice;

public sealed record UpdateTicketTypePriceCommand(
    Guid TicketTypeId,
    decimal Price
) : IRequest;