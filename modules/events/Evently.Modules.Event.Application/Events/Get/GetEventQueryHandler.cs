using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Get;

public class GetEventQueryHandler(
    IEventsDbContext dbContext
) : IRequestHandler<GetEventQuery, EventEntity>
{
    public async Task<EventEntity> Handle(GetEventQuery request, CancellationToken cancellationToken)
        => await dbContext.Events
               .AsNoTracking()
               .Include(e => e.TicketTypes)
               .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken)
           ?? throw new KeyNotFoundException("Event with given id is not found.");
}