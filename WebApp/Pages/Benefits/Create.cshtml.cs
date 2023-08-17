using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Benefits
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = default!;

        [BindProperty]
        public decimal EmployeeDeduction { get; set; }

        [BindProperty]
        public decimal CompanyContribution { get; set; }

        private readonly IBenefitService _benefitService;

        public CreateModel(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _benefitService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
