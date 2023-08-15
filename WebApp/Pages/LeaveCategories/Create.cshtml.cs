using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.LeaveCategories
{
    public class CreateModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [Required]
        [BindProperty]
        public int Allocation { get; set; }

        private readonly ILeaveCategoryService _leaveCategoryService;

        public CreateModel(ILeaveCategoryService leaveCategoryService)
        {
            _leaveCategoryService = leaveCategoryService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _leaveCategoryService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
