using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Salutations
{
    public class IndexModel : PageModel
    {
        public IEnumerable<SalutationIndexModel> Salutations { get; set; }

        private readonly ISalutationService _salutationService;

        public IndexModel(ISalutationService salutationService)
        {
            _salutationService = salutationService;
            Salutations = Enumerable.Empty<SalutationIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Salutations = await _salutationService.GetAll();
        }
    }
}
