using shelter.Application.Common.Interfaces.Service;

namespace shelter.DataAccess.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
