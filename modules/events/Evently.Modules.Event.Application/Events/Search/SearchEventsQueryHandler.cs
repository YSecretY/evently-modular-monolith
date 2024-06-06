using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Search;

public class SearchEventsQueryHandler(
    IEventsDbContext dbContext
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
            Events: events,
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            TotalCount: totalCount
        );
    }
}