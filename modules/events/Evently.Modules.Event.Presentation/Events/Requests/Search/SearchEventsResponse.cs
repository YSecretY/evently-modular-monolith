namespace Evently.Modules.Event.Presentation.Events.Requests.Search;

public sealed record SearchEventsResponse(
    List<EventResponse> Events,
    int PageNumber,
    int PageSize,
    int TotalCount
);