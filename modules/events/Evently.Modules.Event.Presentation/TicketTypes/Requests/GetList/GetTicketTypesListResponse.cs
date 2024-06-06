namespace Evently.Modules.Event.Presentation.TicketTypes.Requests.GetList;

public sealed record GetTicketTypesListResponse(
    List<TicketTypeResponse> TicketTypes,
    int PageNumber,
    int PageSize,
    int MaxPages
);