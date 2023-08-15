using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Grades
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public decimal MinimumSalary { get; set; }

        [BindProperty]
        public decimal MaximumSalary { get; set; }

        private readonly IGradeService _gradeService;

        public CreateModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _gradeService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
