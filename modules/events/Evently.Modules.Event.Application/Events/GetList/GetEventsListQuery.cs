using MediatR;

namespace Evently.Modules.Event.Application.Events.GetList;

public sealed record GetEventsListQuery(int PageSize, int PageNumber) : IRequest<GetEventsListQueryResponse>;