using MediatR;

namespace Evently.Modules.Events.Application.Events.Queries.Get;

public sealed record GetEventQuery(Guid EventId) : IRequest<EventDto>;