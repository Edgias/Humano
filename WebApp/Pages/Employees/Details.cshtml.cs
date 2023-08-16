using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public CheckInModalModel CheckInModalModel { get; set; } = new();

        [BindProperty]
        public LeaveModalModel LeaveModalModel { get; set; } = new(); 

        [BindProperty]
        public QualificationModalModel QualificationModalModel { get; set; } = new();

        [BindProperty]
        public TimesheetModalModel TimesheetModalModel { get; set; } = new();

        [BindProperty]
        public WorkExperienceModalModel WorkExperienceModalModel { get; set; } = new();

        public EmployeeDetailsModel Employee { get; set; } = null!;

        private readonly IEmployeeService _employeeService;
        private readonly IJobTitleService _jobTitleService;
        private readonly IGradeService _gradeService;
        private readonly ILeaveCategoryService _leaveCategoryService;

        public DetailsModel(IEmployeeService employeeService,
            IJobTitleService jobTitleService,
            IGradeService gradeService,
            ILeaveCategoryService leaveCategoryService)
        {
            _employeeService = employeeService;    
            _jobTitleService = jobTitleService;
            _gradeService = gradeService;
            _leaveCategoryService = leaveCategoryService;
            //WorkExperienceModalModel = new WorkExperienceModalModel();
        }

        public async Task OnGet(Guid id)
        {
            Employee = await _employeeService.GetEmployeeWithAllDetailsById(id);
            var jobTitles = await _jobTitleService.GetAll();
            var grades = await _gradeService.GetAll();
            var leaveCategories = await _leaveCategoryService.GetAll();
            var durations = new List<string>() { "All Day", "Half Day" };

            CheckInModalModel.EmployeeId = id;
            LeaveModalModel.EmployeeId = id;
            LeaveModalModel.Durations = new SelectList(durations.Select(d => new { Id = d, Name = d }), "Id", "Name");
            QualificationModalModel.EmployeeId = id;
            TimesheetModalModel.EmployeeId = id;
            WorkExperienceModalModel.EmployeeId = id;
            LeaveModalModel.LeaveCategories = new SelectList(leaveCategories, "Id", "Name");
            WorkExperienceModalModel.JobTitles = new SelectList(jobTitles, "Id", "Name");
            WorkExperienceModalModel.Grades = new SelectList(grades, "Id", "Name");
        }

        public async Task<IActionResult> OnPostCheckIn()
        {
            await _employeeService.AddCheckIn(CheckInModalModel);

            return RedirectToPage("./Details", new { id = CheckInModalModel.EmployeeId });
        }

        public async Task<IActionResult> OnPostLeave()
        {
            await _employeeService.AddLeave(LeaveModalModel);

            return RedirectToPage("./Details", new { id = LeaveModalModel.EmployeeId });
        }

        public async Task<IActionResult> OnPostQualification()
        {
            await _employeeService.AddQualification(QualificationModalModel);

            return RedirectToPage("./Details", new { id = QualificationModalModel.EmployeeId });
        }

        public async Task<IActionResult> OnPostTimesheet()
        {
            await _employeeService.AddTimesheet(TimesheetModalModel);

            return RedirectToPage("./Details", new { id = TimesheetModalModel.EmployeeId });
        }

        public async Task<IActionResult> OnPostWorkExperience()
        {
            await _employeeService.AddWorkExperience(WorkExperienceModalModel);

            return RedirectToPage("./Details", new { id = WorkExperienceModalModel.EmployeeId });
        }
    }
}
