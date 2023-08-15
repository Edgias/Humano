using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Departments
{
    public class IndexModel : PageModel
    {
        public IEnumerable<DepartmentIndexModel> Departments { get; set; }

        private readonly IDepartmentService _departmentService;

        public IndexModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            Departments = Enumerable.Empty<DepartmentIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Departments = await _departmentService.GetAll();
        }
    }
}
