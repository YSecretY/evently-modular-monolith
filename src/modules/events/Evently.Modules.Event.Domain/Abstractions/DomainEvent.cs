namespace Evently.Modules.Event.Domain.Abstractions;

public abstract class DomainEvent(Guid id, DateTime occuredAtUtc) : IDomainEvent
{
    protected DomainEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
    }

    public Guid Id { get; init; } = id;

    public DateTime OccuredAtUtc { get; init; } = occuredAtUtc;
}