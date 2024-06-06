namespace Evently.Shared.Application.Abstractions.Time;

public interface IDateTimeProvider
{
    public DateTime CurrentTime { get; }
}