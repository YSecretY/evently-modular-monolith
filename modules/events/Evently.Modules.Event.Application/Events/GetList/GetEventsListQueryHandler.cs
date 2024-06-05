using System.ComponentModel.DataAnnotations;
using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.GetList;

public class GetEventsListQueryHandler(
    IEventsDbContext dbContext
) : IRequestHandler<GetEventsListQuery, GetEventsListQueryResponse>
{
    public async Task<GetEventsListQueryResponse> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var maxPages = (int)Math.Ceiling((double)await dbContext.Events.CountAsync(cancellationToken) / request.PageSize);

        if (request.PageNumber > maxPages)
            throw new ValidationException("Request page number cannot be greater than max pages.");

        List<EventEntity> events = await dbContext.Events
            .Include(e => e.TicketTypes)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetEventsListQueryResponse
        (
            Events: events,
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            MaxPages: maxPages
        );
    }
}