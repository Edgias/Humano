using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.ApplicationCore.Specifications;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Services
{
    public class CalendarRulesService : ICalendarRulesService
    {
        private readonly IAsyncRepository<CalendarSetting> _calendarSettingRepository;
        private readonly IAsyncRepository<Leave> _leaveRepository;
        private readonly IAsyncRepository<LeaveCategory> _leaveCategoryRepository;

        public CalendarRulesService(IAsyncRepository<CalendarSetting> calendarSettingRepository,
            IAsyncRepository<Leave> leaveRepository,
            IAsyncRepository<LeaveCategory> leaveCategoryRepository)
        {
            _calendarSettingRepository = calendarSettingRepository;
            _leaveRepository = leaveRepository;
            _leaveCategoryRepository = leaveCategoryRepository;
        }

        public async Task<float> 
            HasAvailableDays(Guid employeeId, Guid categoryId, 
            DateTime startDate, DateTime endDate)
        {

            LeaveCategory leaveCategory = await _leaveCategoryRepository.GetByIdAsync(categoryId);


            // get category days between dates
            IEnumerable<Leave> categoryRequests =
                await _leaveRepository.GetAsync(new LeaveSpecification(employeeId, categoryId, startDate, endDate));

            float categoryDaysTaken = 0;
            float halfDaysLeaveInYear = 0;
            float fullDaysLeaveInYear = 0;
            foreach (Leave categoryRequest in categoryRequests)
            {
                foreach (LeaveDay day in categoryRequest.LeaveDays)
                {

                    if (day.DayType == DayType.FullDay)
                    {
                        fullDaysLeaveInYear += 1;
                    }
                    else if (day.DayType == DayType.HalfDay)
                    {
                        halfDaysLeaveInYear += 1;
                    }

                }

                categoryDaysTaken = fullDaysLeaveInYear + (halfDaysLeaveInYear / 2);
            }

            float availableDays = leaveCategory.Allocation - categoryDaysTaken;

            return availableDays;

        }

        public async Task<bool> HasExistingBooking(Guid employeeId, DateTime startDate, DateTime endDate, 
            bool isHalfDay, HourPeriod hourPeriod)
        {
            // Get user booked individual days and half days
            IEnumerable<Leave> bookedDates = 
                await _leaveRepository.GetAsync(new LeaveSpecification(employeeId, startDate, endDate));
            bool hasBooking = false;
            List<LeaveDay> bookedDays = new();
            foreach (Leave day in bookedDates)
            {
                bookedDays.AddRange(day.LeaveDays);
            }


            if (!isHalfDay)
            {
                int range = (endDate - startDate).Days;

                // Check if day is not booked
                foreach (LeaveDay calendarDay in bookedDays)
                {
                    for (int i = 0; i <= range; i++)
                    {
                        DateTime date = startDate.AddDays(i);
                        if (calendarDay.Day == date.Day && calendarDay.Month == date.Month && 
                            calendarDay.Year == date.Year)
                        {
                            hasBooking = true;
                        }

                    }
                }

            }
            else
            {
                List<LeaveDay> potentialHalfDays = new();
                foreach (LeaveDay calendarDay in bookedDays)
                {
                    if (calendarDay.Day == startDate.Day && calendarDay.Month == startDate.Month && 
                        calendarDay.Year == startDate.Year)
                    {
                        potentialHalfDays.Add(calendarDay);
                    }
                }

                if (potentialHalfDays.Where(x => x.DayType == DayType.FullDay).Any())
                {
                    hasBooking = true;
                }
                else if (potentialHalfDays.Where(x => x.DayType == DayType.HalfDay).Any())
                {
                    foreach (LeaveDay day in potentialHalfDays.Where(x => x.DayType == DayType.HalfDay).ToList())
                    {
                        if (day.HourPeriod == hourPeriod)
                        {
                            hasBooking = true;
                        }
                    }

                }
            }

            return hasBooking;
        }

        public async Task<(DateTime startDate, DateTime endDate)> GetInitialCalendarDates()
        {
            DateTime calendarStartDate;
            DateTime calendarEndDate;

            CalendarSetting calendarSetting = 
                await _calendarSettingRepository.FirstOrDefaultAsync(new CalendarSettingSpecification());

            calendarStartDate = calendarSetting != null ?
                new(DateTime.Now.Year, calendarSetting.Month, calendarSetting.Day) :
                new(DateTime.Now.Year, 1, 1);

            DateTime date;

            int yearDifference = DateTime.Now.Year - calendarStartDate.Year;

            if (yearDifference == 0)
            {
                date = calendarStartDate.AddMonths(11);
            }
            else
            {
                DateTime newStartDate = new(calendarStartDate.Year + yearDifference, 
                    calendarStartDate.Month, calendarStartDate.Day);
                date = newStartDate.AddMonths(11);
            }

            calendarEndDate = calendarSetting != null ?
                new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)) :
                new(DateTime.Now.Year, 12, 31);

            return (calendarStartDate, calendarEndDate);
        }
    }
}
