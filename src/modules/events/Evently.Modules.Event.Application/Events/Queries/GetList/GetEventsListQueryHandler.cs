using System.ComponentModel.DataAnnotations;
using Evently.Modules.Event.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Queries.GetList;

public class GetEventsListQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetEventsListQuery, GetEventsListQueryResponse>
{
    public async Task<GetEventsListQueryResponse> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var maxPages = (int)Math.Ceiling((double)await dbContext.Events.CountAsync(cancellationToken) / request.PageSize);

        if (maxPages is 0)
            throw new KeyNotFoundException("No events.");

        if (request.PageNumber > maxPages)
            throw new ValidationException("Request page number cannot be greater than max pages.");

        var events = await dbContext.Events
            .Include(e => e.TicketTypes)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetEventsListQueryResponse
        (
            Events: mapper.Map<List<EventDto>>(events),
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            MaxPages: maxPages
        );
    }
}