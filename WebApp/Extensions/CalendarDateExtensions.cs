using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Extensions
{
    public static class CalendarDateExtensions
    {
        public static LeaveDay GenerateDay(this DateTime date, bool isHalfDay, HourPeriod hourPeriod)
        {
            var dayType = isHalfDay ? DayType.HalfDay : DayType.FullDay;

            LeaveDay leaveDay = new(date.Day, date.Month, date.Year, dayType, hourPeriod);
            
            return leaveDay;
        }

    }
}
