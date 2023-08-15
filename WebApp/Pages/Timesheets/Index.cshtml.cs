using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Timesheets
{
    public class IndexModel : PageModel
    {
        public IEnumerable<TimesheetIndexModel> Timesheets { get; set; }

        private readonly ITimesheetService _timesheetService;

        public IndexModel(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
            Timesheets = Enumerable.Empty<TimesheetIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Timesheets = await _timesheetService.GetAll();
        }
    }
}
