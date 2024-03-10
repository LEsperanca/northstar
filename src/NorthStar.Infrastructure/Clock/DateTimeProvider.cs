using NorthStar.Application.Abstractions.Clock;

namespace NorthStar.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
