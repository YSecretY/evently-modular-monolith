using Evently.Shared.Application.Abstractions.Time;

namespace Evently.Shared.Infrastructure.Implementation.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}