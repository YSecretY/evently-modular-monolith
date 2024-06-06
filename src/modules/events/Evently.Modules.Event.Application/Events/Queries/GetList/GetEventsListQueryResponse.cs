using Evently.Modules.Event.Domain.Events;

namespace Evently.Modules.Event.Application.Events.Queries.GetList;

public sealed record GetEventsListQueryResponse(
    List<EventEntity> Events,
    int PageNumber,
    int PageSize,
    int MaxPages
);