using MediatR;

namespace Evently.Modules.Events.Application.TicketTypes.Queries.GetList;

public sealed record GetTicketTypesListQuery(
    int PageSize,
    int PageNumber
) : IRequest<GetTicketTypesListQueryResponse>;