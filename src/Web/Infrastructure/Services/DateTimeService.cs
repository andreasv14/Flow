using Flow.WebAPI.Application.Common.Interfaces;

namespace Flow.WebAPI.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
