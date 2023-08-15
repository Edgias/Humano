using Edgias.Humano.WebApp.Pages.Timesheets;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ITimesheetService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<TimesheetIndexModel>> GetAll();
    }
}
