using Evently.Modules.Event.Domain.TicketTypes;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.GetList;

public sealed record GetTicketTypesListQueryResponse(
    List<TicketType> TicketTypes,
    int PageNumber,
    int PageSize,
    int MaxPages
);