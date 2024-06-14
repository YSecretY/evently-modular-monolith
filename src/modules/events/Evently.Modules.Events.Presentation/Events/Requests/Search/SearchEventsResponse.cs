using Evently.Modules.Events.Application.Events;

namespace Evently.Modules.Events.Presentation.Events.Requests.Search;

public sealed record SearchEventsResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int TotalCount
);