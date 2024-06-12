using MediatR;

namespace Evently.Modules.Event.Application.Events.Queries.Get;

public sealed record GetEventQuery(Guid EventId) : IRequest<EventDto>;