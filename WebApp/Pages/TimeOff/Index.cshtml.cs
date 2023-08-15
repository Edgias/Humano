using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.TimeOff
{
    public class IndexModel : PageModel
    {
        public IEnumerable<TimeOffIndexModel> Applications { get; set; }

        private readonly ILeaveService _leaveService;

        public IndexModel(ILeaveService leaveService)
        {
            _leaveService = leaveService;
            Applications = Enumerable.Empty<TimeOffIndexModel>();
        }

        public async Task OnGet()
        {
            Applications = await _leaveService.GetAll();
        }
    }
}
