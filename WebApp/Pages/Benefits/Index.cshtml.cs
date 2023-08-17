using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Benefits
{
    public class IndexModel : PageModel
    {
        public IEnumerable<BenefitIndexModel> Benefits { get; set; } = Enumerable.Empty<BenefitIndexModel>();

        private readonly IBenefitService _benefitService;

        public IndexModel(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        public async Task OnGet()
        {
            Benefits = await _benefitService.GetAll();
        }
    }
}
