using MediatR;

namespace Evently.Modules.Event.Application.TicketTypes.Commands.CreateTicketType;

public sealed record CreateTicketTypeCommand(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
) : IRequest<Guid>;