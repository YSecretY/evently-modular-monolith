using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}