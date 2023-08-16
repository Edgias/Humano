using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.ApplicationCore.Specifications;
using Edgias.Humano.WebApp.Extensions;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Employees;
using Edgias.Humano.WebApp.Pages.TimeOff;

namespace Edgias.Humano.WebApp.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Leave> _leaveRepository;
        private readonly IAsyncRepository<ToDo> _toDoRepository;
        private readonly ICalendarRulesService _calendarRulesService;

        public LeaveService(IAsyncRepository<Employee> employeeRepository,
            IAsyncRepository<Leave> leaveRepository,
            IAsyncRepository<ToDo> toDoRepository,
            ICalendarRulesService calendarRulesService)
        {
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
            _toDoRepository = toDoRepository;
            _calendarRulesService = calendarRulesService;
        }

        public async Task<(bool isCreated, string message)> AddLeave(ApplyModel model)
        {
            return await SubmitLeaveRequest(model.LeaveCategoryId, model.StartDate, model.EndDate, 
                model.HalfDay, model.EmployeeId, model.HourPeriod, model.Duration);
        }

        public async Task<(bool isCreated, string message)> AddLeave(LeaveModalModel model)
        {
            return await SubmitLeaveRequest(model.LeaveCategoryId, model.StartDate, model.EndDate,
                model.HalfDay, model.EmployeeId, model.HourPeriod, model.Duration);
        }

        public async Task<IEnumerable<TimeOffIndexModel>> GetAll()
        {
            var leaves = await _leaveRepository.GetAsync(new LeaveSpecification());

            return leaves.Select(l => new TimeOffIndexModel()
            {
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                Employee = $"{l.Employee.FirstName} {l.Employee.LastName}",
                EmployeeId = l.EmployeeId,
                DateSubmitted = l.CreatedDate.Date,
                LeaveCategory = l.LeaveCategory.Name,
                LeaveStatus = l.LeaveStatus.ToString(),
                Id = l.Id,
                NumberOfDays = l.DaysTaken()
            });
        }

        public Task<IEnumerable<TimeOffIndexModel>> GetAllRequiringMyApproval()
        {
            throw new NotImplementedException();
        }

        private async Task<(bool isCreated, string message)> SubmitLeaveRequest(Guid categoryId, DateTime startDate,
            DateTime endDate, DateTime? halfDay, Guid employeeId, HourPeriod hourPeriod, string duration)
        {
            bool isHalfDay = duration.Equals("Half Day");
            DateTime _startDate = isHalfDay ? halfDay!.Value : startDate;
            DateTime _endDate = _startDate;
            HourPeriod amORpm = HourPeriod.AM;
            DateTime today = DateTime.Now;

            if (!isHalfDay)
            {
                _endDate = endDate;
            }
            else
            {
                amORpm = hourPeriod;
            }

            if (endDate < startDate)
            {
                return (false, "End Date must be greater than Start Date");
            }

            if (_endDate.Year > today.Year + 1)
            {
                return (false, $"You cannot book leave after 31st December {today.Year + 1}");
            }


            // Check for existing booking on this date

            bool hasBooking = await _calendarRulesService.HasExistingBooking(employeeId, _startDate,
                _endDate, isHalfDay, amORpm);

            if (hasBooking)
            {
                return (false, "You have another calendar booking during the days");
            }

            int range = (_endDate - _startDate).Days;

            Leave request = default!;


            // Check for weekends and holidays, and filter days to only include those requests

            List<RequestedDay> requestedDates = new();
            List<LeaveDay> leaveCalendarDays = new();
            for (int i = 0; i <= range; i++)
            {
                bool isWeekend = false;
                bool isHoliday = false;
                DateTime date = _startDate.AddDays(i);

                isWeekend = date.IsWeekend();
                isHoliday = false;
                if (!isWeekend)
                {
                    //HolidayApiModel holidayResponse = await _calendarService.GetHolidays(userCountry,
                    //    date.Year, date.Month, date.Day);

                    //isHoliday = holidayResponse.Holidays.Any();

                    //if (!isHoliday)
                    //{
                    LeaveDay calendarDay = date.GenerateDay(isHalfDay, hourPeriod);

                    leaveCalendarDays.Add(calendarDay);
                    //}
                }

                requestedDates.Add(new() { Date = date, IsHoliday = isHoliday });

            }

            if (requestedDates.All(d => d.Date.IsWeekend() || d.IsHoliday))
            {
                return (false, "You selected only weekends and public holidays. These days are leave anyway");
            }
            request = CalendarDaysGenerator.GenerateRequest(employeeId, categoryId,
                _startDate, _endDate, isHalfDay, hourPeriod);

            List<DateTime> allLeaveDays = new();

            foreach (LeaveDay day in request.LeaveDays)
            {
                DateTime dayInDateForm = new(day.Year, day.Month, day.Day);
                allLeaveDays.Add(dayInDateForm);
            }


            // CHECK TO SEE THEY HAVE ENOUGH FREE DAYS IN THIS CATEGORY


            // Get years that we need to get allocations from
            // Get start date and end date of request
            // Get calendar start date
            // if startdate_month is less than company_calendar_startdate_month, then start_year as request_startdate_year - 1, else start_year is request_startdate_year
            // if enddate_month is less than company_calendar_enddate_month, then end_year as request_startdate_year - 1, else end_year is request_startdate_year
            // Get list of years, with start_date and _end_date

            (DateTime companyCalendarStartdate, DateTime companyCalendarEnddate) =
                await _calendarRulesService.GetInitialCalendarDates();

            int requestStartDateYear = _startDate.Year;
            int requestEndDateYear = _endDate.Year;

            if (_startDate.Month < companyCalendarStartdate.Month)
            {
                requestStartDateYear = _startDate.Year - 1;
            }

            if (_endDate.Month < companyCalendarStartdate.Month)
            {
                requestEndDateYear = _endDate.Year - 1;
            }

            DateTime nextStartDate = new(requestStartDateYear, companyCalendarStartdate.Month, companyCalendarStartdate.Day);
            DateTime nextEndDate = new(requestStartDateYear + 1, companyCalendarEnddate.Month, companyCalendarEnddate.Day);

            List<float> availableDaysByYear = new();

            for (int i = requestStartDateYear; i <= requestEndDateYear; i++)
            {
                float availableDays =
                await _calendarRulesService.HasAvailableDays(employeeId, categoryId,
                nextStartDate, nextEndDate);

                availableDaysByYear.Add(availableDays);

                if (availableDays == 0)
                {
                    return (false, "You do not have enough days left available in this category");
                }

                if (!isHalfDay)
                {
                    List<DateTime> requestedFullDaysInThisYear = allLeaveDays.Where(x => x.Date > nextStartDate).
                    Where(x => x.Date < nextEndDate).ToList();
                    int requestedFullDaysInThisYearCount = requestedFullDaysInThisYear.Count;

                    if (availableDays < requestedFullDaysInThisYearCount)
                    {
                        return (false, "You do not have enough days left available in this category");
                    }
                }


                nextStartDate.AddYears(1);
                nextEndDate.AddYears(1);

            }

            if (request.LeaveDays.Any())
            {
                Leave leave = await _leaveRepository.AddAsync(request);

                if (leave.Id != Guid.Empty)
                {
                    Employee? employee = await _employeeRepository.GetByIdAsync(leave.EmployeeId);

                    if (employee is not null && employee.Manager is not null)
                    {

                        ToDo todo = new($"Leave Application Approval Request - {employee.Manager.FirstName} {employee.Manager.LastName}",
                            employee.Manager.Id, leave.Id, nameof(Leave));
                        await _toDoRepository.AddAsync(todo);
                    }

                    return (true, $"Leave request was submitted successfully.");
                }
                else
                {
                    return (false, $"Error. Leave request did not save");
                }
            }

            return (false, $"Error. Your leave request did not save");
        }
    }
}
