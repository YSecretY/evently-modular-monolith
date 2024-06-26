namespace Evently.Modules.Event.Application.TicketTypes.Queries.GetList;

public sealed record GetTicketTypesListQueryResponse(
    List<TicketTypeDto> TicketTypes,
    int PageNumber,
    int PageSize,
    int MaxPages
);