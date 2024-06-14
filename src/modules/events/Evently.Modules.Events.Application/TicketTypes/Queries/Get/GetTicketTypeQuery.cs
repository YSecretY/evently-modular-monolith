using MediatR;

namespace Evently.Modules.Events.Application.TicketTypes.Queries.Get;

public sealed record GetTicketTypeQuery(
    Guid TicketTypeId
) : IRequest<TicketTypeDto>;