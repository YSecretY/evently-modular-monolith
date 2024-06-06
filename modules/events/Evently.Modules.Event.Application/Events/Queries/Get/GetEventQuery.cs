using Evently.Modules.Event.Domain.Events;
using MediatR;

namespace Evently.Modules.Event.Application.Events.Queries.Get;

public sealed record GetEventQuery(Guid EventId) : IRequest<EventEntity>;