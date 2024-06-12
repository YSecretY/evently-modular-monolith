using Evently.Modules.Event.Application.Events;

namespace Evently.Modules.Event.Presentation.Events.Requests.GetList;

public sealed record GetEventsListResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int MaxPages
);