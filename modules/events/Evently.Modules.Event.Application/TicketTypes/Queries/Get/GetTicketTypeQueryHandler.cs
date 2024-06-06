using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Domain.TicketTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.Get;

public class GetTicketTypeQueryHandler(
    IEventsDbContext dbContext
) : IRequestHandler<GetTicketTypeQuery, TicketType>
{
    public async Task<TicketType> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken) =>
        await dbContext.TicketTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.TicketTypeId, cancellationToken)
        ?? throw new KeyNotFoundException("Ticket type is not found.");
}