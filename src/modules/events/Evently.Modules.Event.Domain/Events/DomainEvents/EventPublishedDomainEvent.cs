using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Events.DomainEvents;

public class EventPublishedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; set; } = eventId;
}