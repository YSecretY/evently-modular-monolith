namespace Evently.Modules.Event.Presentation.Events.Requests.GetList;

public sealed record GetEventsListResponse(
    List<EventResponse> Events,
    int PageNumber,
    int PageSize,
    int MaxPages
);