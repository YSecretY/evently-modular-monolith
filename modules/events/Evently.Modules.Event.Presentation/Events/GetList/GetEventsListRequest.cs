namespace Evently.Modules.Event.Presentation.Events.GetList;

public sealed record GetEventsListRequest(int PageSize, int PageNumber);