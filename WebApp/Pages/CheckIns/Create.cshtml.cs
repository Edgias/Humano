using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.CheckIns
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Guid EmployeeId { get; set; }

        [BindProperty]
        public DateTime Date { get; set; } = DateTime.Now;

        [BindProperty]
        public string TimeIn { get; set; } = string.Empty;

        [BindProperty]
        public string? TimeOut { get; set; }

        private readonly ICheckInService _checkInService;

        public CreateModel(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        public void OnGet(Guid id)
        {
            EmployeeId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            await _checkInService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
