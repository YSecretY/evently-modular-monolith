using Evently.Modules.Event.Application.TicketTypes;

namespace Evently.Modules.Event.Presentation.TicketTypes.Requests.GetList;

public sealed record GetTicketTypesListResponse(
    List<TicketTypeDto> TicketTypes,
    int PageNumber,
    int PageSize,
    int MaxPages
);