namespace Evently.Modules.Events.Presentation.TicketTypes.Requests.GetList;

public sealed record GetTicketTypesListRequest(
    int PageSize,
    int PageNumber
);