using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.LeaveCategories
{
    public class IndexModel : PageModel
    {
        public IEnumerable<LeaveCategoryIndexModel> LeaveCategories { get; set; } 

        private readonly ILeaveCategoryService _leaveCategoryService;

        public IndexModel(ILeaveCategoryService leaveCategoryService)
        {
            _leaveCategoryService = leaveCategoryService;
            LeaveCategories = Enumerable.Empty<LeaveCategoryIndexModel>();
        }

        public async Task OnGetAsync()
        {
            LeaveCategories = await _leaveCategoryService.GetAll();
        }
    }
}
