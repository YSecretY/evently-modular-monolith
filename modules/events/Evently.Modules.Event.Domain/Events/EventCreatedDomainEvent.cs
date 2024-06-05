using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}