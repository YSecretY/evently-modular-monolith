namespace Evently.Modules.Event.Infrastructure.Services.Time;

public interface IDateTimeProvider
{
    public DateTime CurrentTime { get; }
}