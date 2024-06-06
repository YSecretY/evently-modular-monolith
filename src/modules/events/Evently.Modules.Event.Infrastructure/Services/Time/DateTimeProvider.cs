using Evently.Modules.Event.Application.Abstraction;

namespace Evently.Modules.Event.Infrastructure.Services.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}