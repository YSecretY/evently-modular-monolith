using Evently.Shared.Application.Abstractions.Time;

namespace Evently.Shared.Infrastructure.AbstractionsImplementation.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}