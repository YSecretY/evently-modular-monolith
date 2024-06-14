using MediatR;

namespace Evently.Modules.Events.Application.TicketTypes.Commands.Create;

public sealed record CreateTicketTypeCommand(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity
) : IRequest<Guid>;