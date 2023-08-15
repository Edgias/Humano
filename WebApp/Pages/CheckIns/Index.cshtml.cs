using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.CheckIns
{
    public class IndexModel : PageModel
    {
        public IEnumerable<CheckInIndexModel> CheckIns { get; set; }

        private readonly ICheckInService _checkInService;

        public IndexModel(ICheckInService checkInService)
        {
            _checkInService = checkInService;
            CheckIns = Enumerable.Empty<CheckInIndexModel>();
        }

        public async Task OnGetAsync()
        {
            CheckIns = await _checkInService.GetAll();
        }
    }
}
