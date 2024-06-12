using MediatR;

namespace Evently.Modules.Event.Application.Events.Queries.GetList;

public sealed record GetEventsListQuery(int PageSize, int PageNumber) : IRequest<GetEventsListQueryResponse>;