namespace Evently.Shared.Domain.Abstractions;

public interface IDomainEvent
{
    public Guid Id { get; }

    DateTime OccuredAtUtc { get; }
}