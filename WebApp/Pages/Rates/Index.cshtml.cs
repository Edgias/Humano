using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Rates
{
    public class IndexModel : PageModel
    {
        public IEnumerable<RateIndexModel> Rates { get; set; }

        private readonly IRateService _rateService;

        public IndexModel(IRateService rateService)
        {
            _rateService = rateService;
            Rates = Enumerable.Empty<RateIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Rates = await _rateService.GetAll();
        }
    }
}
