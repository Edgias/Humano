using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public IEnumerable<EmployeeIndexModel> Employees { get; set; } 

        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Employees = Enumerable.Empty<EmployeeIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Employees = await _employeeService.GetAll();
        }
    }
}
