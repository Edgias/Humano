using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public WorkExperienceModalModel WorkExperienceModalModel { get; set; }

        public EmployeeDetailsModel Employee { get; set; } = null!;

        private readonly IEmployeeService _employeeService;
        private readonly IJobTitleService _jobTitleService;
        private readonly IGradeService _gradeService;

        public DetailsModel(IEmployeeService employeeService,
            IJobTitleService jobTitleService,
            IGradeService gradeService)
        {
            _employeeService = employeeService;    
            _jobTitleService = jobTitleService;
            _gradeService = gradeService;
            WorkExperienceModalModel = new WorkExperienceModalModel();
        }

        public async Task OnGet(Guid id)
        {
            Employee = await _employeeService.GetEmployeeWithAllDetailsById(id);
            var jobTitles = await _jobTitleService.GetAll();
            var grades = await _gradeService.GetAll();
            WorkExperienceModalModel.EmployeeId = id;
            WorkExperienceModalModel.JobTitles = new SelectList(jobTitles, "Id", "Name");
            WorkExperienceModalModel.Grades = new SelectList(jobTitles, "Id", "Name");
        }

        public async Task OnPostWorkExperience()
        {
            await _employeeService.AddWorkExperience(WorkExperienceModalModel);
        }
    }
}
