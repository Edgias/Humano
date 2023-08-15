using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ICalendarRulesService
    {
        Task<bool> HasExistingBooking(Guid employeeId, DateTime startDate, DateTime endDate,
            bool isHalfDay, HourPeriod hourPeriod);

        Task<float> HasAvailableDays(Guid employeeId, Guid categoryId, 
            DateTime startDate, DateTime endDate);

        Task<(DateTime startDate, DateTime endDate)> GetInitialCalendarDates();

    }
}
