namespace Evently.Modules.Event.Infrastructure.Services.Time.Implementation;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}