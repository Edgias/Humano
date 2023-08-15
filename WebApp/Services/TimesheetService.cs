using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Timesheets;

namespace Edgias.Humano.WebApp.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly IAsyncRepository<Timesheet> _repository;

        public TimesheetService(IAsyncRepository<Timesheet> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Timesheet timesheet = new(model.Description, model.Date, model.NumberOfHours, model.EmployeeId);

            await _repository.AddAsync(timesheet);
        }

        public async Task<IEnumerable<TimesheetIndexModel>> GetAll()
        {
            IReadOnlyList<Timesheet> timesheets = await _repository.GetAllAsync();

            return timesheets.Select(d => new TimesheetIndexModel()
            {
                Id = d.Id,
                Description = d.Description,
                NumberOfHours = d.NumberOfHours,
                EmployeeId = d.EmployeeId,
                Date = d.Date,
                Employee = $"{d.Employee?.FirstName} {d.Employee?.LastName}",
            });
        }

    }
}
