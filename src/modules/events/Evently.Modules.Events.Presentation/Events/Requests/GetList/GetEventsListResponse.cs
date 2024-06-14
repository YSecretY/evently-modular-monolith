using Evently.Modules.Events.Application.Events;

namespace Evently.Modules.Events.Presentation.Events.Requests.GetList;

public sealed record GetEventsListResponse(
    List<EventDto> Events,
    int PageNumber,
    int PageSize,
    int MaxPages
);