using MediatR;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.GetList;

public sealed record GetTicketTypesListQuery(
    int PageSize,
    int PageNumber
) : IRequest<GetTicketTypesListQueryResponse>;