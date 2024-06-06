using MediatR;

namespace Evently.Modules.Event.Application.Events.Search;

public sealed record SearchEventsQuery(
    Guid? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    int PageNumber,
    int PageSize
) : IRequest<SearchEventsQueryResponse>;