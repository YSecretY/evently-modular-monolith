using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public class EventPublishedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; set; } = eventId;
}