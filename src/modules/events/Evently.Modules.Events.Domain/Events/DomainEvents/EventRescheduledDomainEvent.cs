using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public class EventRescheduledDomainEvent(Guid eventId, DateTime startsAtUtc, DateTime? endsAtUtc) : DomainEvent
{
    public Guid EventId { get; set; } = eventId;

    public DateTime StartsAtUtc { get; } = startsAtUtc;

    public DateTime? EndsAtUtc { get; } = endsAtUtc;
}