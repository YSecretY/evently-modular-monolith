using Evently.Modules.Event.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Queries.Search;

public class SearchEventsQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<SearchEventsQuery, SearchEventsQueryResponse>
{
    public async Task<SearchEventsQueryResponse> Handle(SearchEventsQuery request, CancellationToken cancellationToken)
    {
        var eventsQuery = dbContext.Events
            .AsNoTracking()
            .Include(e => e.TicketTypes)
            .Where(e =>
                (e.CategoryId == request.CategoryId || request.CategoryId == null) &&
                (e.StartsAtUtc == request.StartDate || request.StartDate == null) &&
                (e.EndsAtUtc == request.EndDate || request.EndDate == null));

        var totalCount = await eventsQuery.CountAsync(cancellationToken);

        var events = await eventsQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new SearchEventsQueryResponse
        (
            Events: mapper.Map<List<EventDto>>(events),
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            TotalCount: totalCount
        );
    }
}