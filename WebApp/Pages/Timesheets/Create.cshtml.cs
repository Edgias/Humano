using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Timesheets
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Description { get; set; } = default!;

        [BindProperty]
        public DateTime Date { get; set; } = DateTime.Now;

        [BindProperty]
        public int NumberOfHours { get; set; }

        [BindProperty]
        public Guid EmployeeId { get; set; }

        private readonly ITimesheetService _timesheetService;

        public CreateModel(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        public void OnGet(Guid id)
        {
            EmployeeId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            await _timesheetService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
