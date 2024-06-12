using Evently.Modules.Event.Application.Events;

namespace Evently.Modules.Event.Presentation.Events.Requests.Search;

public sealed record SearchEventsResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int TotalCount
);