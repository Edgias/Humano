using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Extensions
{
    public static class DateExtensions
    {
        public static DateTime GetStartDate(this CalendarSetting clientCalendarSetting, DateTime clientRegistrationDate)
        {
            if (clientCalendarSetting.Month > clientRegistrationDate.Month)
            {
                return new(clientRegistrationDate.Year - 1, clientCalendarSetting.Month, 1);
            }
            else
            {
                return new(clientRegistrationDate.Year, clientCalendarSetting.Month, 1);
            }
        }

        public static DateTime GetCurrentStartDate(this DateTime calendarStartDate)
        {
            return new(DateTime.Now.Year, calendarStartDate.Month, calendarStartDate.Day);
        }

        public static DateTime GetCurrentEndDate(this DateTime calendarCurrentStartDate)
        {
            DateTime date;

            int yearDifference = DateTime.Now.Year - calendarCurrentStartDate.Year;

            if (yearDifference == 0)
            {
                date = calendarCurrentStartDate.AddMonths(11);
            }
            else
            {
                DateTime newStartDate = new(calendarCurrentStartDate.Year + yearDifference, calendarCurrentStartDate.Month, calendarCurrentStartDate.Day);
                date = newStartDate.AddMonths(11);
            }

            return new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

        }

        public static DateTime GetEndDate(this DateTime startDate)
        {
            DateTime date = startDate.AddMonths(11);

            DateTime endDate = new(date.Year, date.Month, date.Day);

            return new(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));

        }

        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
        }
    }
}
