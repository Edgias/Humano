using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Projects
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = default!;

        [BindProperty]
        public string Description { get; set; } = default!;

        [BindProperty]
        public int Duration { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [BindProperty]
        public DateTime? EndDate { get; set; }

        private readonly IProjectService _projectService;

        public CreateModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _projectService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
