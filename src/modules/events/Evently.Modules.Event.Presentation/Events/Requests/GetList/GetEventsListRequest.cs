namespace Evently.Modules.Event.Presentation.Events.Requests.GetList;

public sealed record GetEventsListRequest(int PageSize, int PageNumber);