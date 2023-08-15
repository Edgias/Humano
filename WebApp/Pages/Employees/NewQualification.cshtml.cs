using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class NewQualificationModel : PageModel
    {
        [BindProperty]
        public string School { get; set; } = string.Empty;

        [BindProperty]
        public QualificationLevel Level { get; set; }

        [BindProperty]
        public string FieldOfStudy { get; set; } = string.Empty;

        [BindProperty]
        public string Grade { get; set; } = string.Empty;

        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        public Guid EmployeeId { get; set; }

        private readonly IEmployeeQualificationService _employeeQualificationService;

        public NewQualificationModel(IEmployeeQualificationService employeeQualificationService)
        {
            _employeeQualificationService = employeeQualificationService;
        }

        public void OnGet(Guid id)
        {
            EmployeeId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            await _employeeQualificationService.Create(this);

            return RedirectToPage("./Details", new { id = EmployeeId });
        }
    }
}
