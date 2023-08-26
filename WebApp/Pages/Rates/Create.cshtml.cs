using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Rates
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = default!;

        [BindProperty]
        public decimal Amount { get; set; }

        private readonly IRateService _rateService;

        public CreateModel(IRateService rateService)
        {
            _rateService = rateService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _rateService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
