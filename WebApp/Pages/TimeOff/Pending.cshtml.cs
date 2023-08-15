using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.TimeOff
{
    public class PendingModel : PageModel
    {
        public IEnumerable<TimeOffIndexModel> Applications { get; set; }

        public void OnGet()
        {
        }
    }
}
