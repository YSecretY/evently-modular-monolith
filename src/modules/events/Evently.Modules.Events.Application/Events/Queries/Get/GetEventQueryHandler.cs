using Evently.Modules.Events.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Events.Queries.Get;

public class GetEventQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetEventQuery, EventDto>
{
    public async Task<EventDto> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events
                              .AsNoTracking()
                              .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken)
                          ?? throw new KeyNotFoundException("Event is not found.");

        return mapper.Map<EventDto>(eventEntity);
    }
}