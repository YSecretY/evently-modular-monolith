namespace Evently.Modules.Events.Application.Events.Queries.Search;

public sealed record SearchEventsQueryResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int TotalCount
);