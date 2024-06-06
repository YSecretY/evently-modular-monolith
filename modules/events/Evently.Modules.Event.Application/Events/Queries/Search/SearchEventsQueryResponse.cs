using Evently.Modules.Event.Domain.Events;

namespace Evently.Modules.Event.Application.Events.Queries.Search;

public sealed record SearchEventsQueryResponse(
    List<EventEntity> Events,
    int PageNumber,
    int PageSize,
    int TotalCount
);