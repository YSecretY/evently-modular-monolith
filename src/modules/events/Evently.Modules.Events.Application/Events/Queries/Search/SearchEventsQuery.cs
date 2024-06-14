using MediatR;

namespace Evently.Modules.Events.Application.Events.Queries.Search;

public sealed record SearchEventsQuery(
    Guid? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    int PageNumber,
    int PageSize
) : IRequest<SearchEventsQueryResponse>;