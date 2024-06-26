using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Events.DomainEvents;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; set; } = eventId;
}