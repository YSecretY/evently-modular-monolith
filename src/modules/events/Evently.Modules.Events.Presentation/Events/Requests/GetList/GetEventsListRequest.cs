namespace Evently.Modules.Events.Presentation.Events.Requests.GetList;

public sealed record GetEventsListRequest(int PageSize, int PageNumber);