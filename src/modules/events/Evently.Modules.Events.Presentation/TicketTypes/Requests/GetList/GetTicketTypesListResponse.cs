using Evently.Modules.Events.Application.TicketTypes;

namespace Evently.Modules.Events.Presentation.TicketTypes.Requests.GetList;

public sealed record GetTicketTypesListResponse(
    List<TicketTypeDto> TicketTypes,
    int PageNumber,
    int PageSize,
    int MaxPages
);