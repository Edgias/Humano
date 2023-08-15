using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public EmployeeType EmployeeType { get; set; }

        [BindProperty]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [BindProperty]
        public string LastName { get; set; } = string.Empty;

        [BindProperty]
        public string NationalId { get; set; } = string.Empty;

        [BindProperty]
        public DateTime DateJoined { get; set; } = DateTime.Now;

        [BindProperty]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [BindProperty]
        public Gender Gender { get; set; }

        [BindProperty]
        public Guid DepartmentId { get; set; }

        [BindProperty]
        public Guid? ManagerId { get; set; }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string Mobile { get; set; } = string.Empty;

        [BindProperty]
        public string Street { get; set; } = string.Empty;

        [BindProperty]
        public string City { get; set; } = string.Empty;

        [BindProperty]
        public string? State { get; set; }

        [BindProperty]
        public string? Country { get; set; } = "Zimbabwe";

        [BindProperty]
        public Guid SalutationId { get; set; }

        public SelectList? Salutations { get; set; }
        public SelectList? Departments { get; set; }
        public SelectList? Managers { get; set; }

        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ISalutationService _salutationService;

        public CreateModel(IDepartmentService departmentService,
            IEmployeeService employeeService,
            ISalutationService salutationService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
            _salutationService = salutationService;
        }

        public async Task OnGet()
        {
            var departments = await _departmentService.GetAll();
            var salutations = await _salutationService.GetAll();
            Salutations = new SelectList(salutations, "Id", "Name");
            Departments = new SelectList(departments, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            await _employeeService.Create(this);

            return RedirectToPage("./Index");
        }
    }
}
