namespace Evently.Modules.Event.Presentation.TicketTypes.Requests.GetList;

public sealed record GetTicketTypesListRequest(
    int PageSize,
    int PageNumber
);