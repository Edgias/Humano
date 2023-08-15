using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Extensions
{
    public static class CalendarDaysGenerator
    {
        public static Leave GenerateRequest(Guid employeeId, DateTime startDate, 
            DateTime endDate, Guid categoryId)
        {
            return new Leave(employeeId, startDate, endDate, LeaveStatus.UnAuthorised, categoryId);
        }

        public static Leave GenerateRequest(Guid employeeId, Guid categoryId, 
            DateTime startDate, DateTime endDate, bool isHalfDay, HourPeriod hourPeriod)
        {
            int range = (endDate - startDate).Days;

            List<LeaveDay> leaveDays = new();

            for (int i = 0; i <= range; i++)
            {
                DateTime date = startDate.AddDays(i);
                LeaveDay calendarDay = date.GenerateDay(isHalfDay, hourPeriod);
                
                leaveDays.Add(calendarDay);
            }

            Leave leave = new(employeeId, startDate, endDate,
                LeaveStatus.UnAuthorised, categoryId, leaveDays);

            return leave;
        }
    }
}
