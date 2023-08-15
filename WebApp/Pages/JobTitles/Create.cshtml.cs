using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.JobTitles
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        private readonly IJobTitleService _jobTitleService;

        public CreateModel(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _jobTitleService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
