namespace Evently.Modules.Events.Application.Events.Queries.GetList;

public sealed record GetEventsListQueryResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int MaxPages
);