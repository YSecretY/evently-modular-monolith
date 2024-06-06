using Evently.Modules.Event.Domain.TicketTypes;
using MediatR;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.Get;

public sealed record GetTicketTypeQuery(
    Guid TicketTypeId
) : IRequest<TicketType>;