namespace Evently.Modules.Event.Application.Abstraction;

public interface IDateTimeProvider
{
    public DateTime CurrentTime { get; }
}