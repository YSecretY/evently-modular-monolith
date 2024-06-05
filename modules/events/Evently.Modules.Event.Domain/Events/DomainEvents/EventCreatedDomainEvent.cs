using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Events.DomainEvents;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}