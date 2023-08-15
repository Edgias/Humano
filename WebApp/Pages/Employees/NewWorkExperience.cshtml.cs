using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class NewWorkExperienceModel : PageModel
    {
        [BindProperty]
        public decimal Salary { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        public Guid GradeId { get; set; }

        [BindProperty]
        public Guid JobTitleId { get; set; }

        [BindProperty]
        public Guid EmployeeId { get; set; }

        public SelectList JobTitles { get; set; }

        public SelectList Grades { get; set; }

        public void OnGet()
        {
        }
    }
}
