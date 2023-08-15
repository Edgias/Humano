using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Departments
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string? Email { get; set; }

        private readonly IDepartmentService _departmentService;

        public CreateModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _departmentService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
