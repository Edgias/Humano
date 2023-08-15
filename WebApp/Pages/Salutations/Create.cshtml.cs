using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Salutations
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        private readonly ISalutationService _salutationService;

        public CreateModel(ISalutationService salutationService)
        {
            _salutationService = salutationService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _salutationService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
