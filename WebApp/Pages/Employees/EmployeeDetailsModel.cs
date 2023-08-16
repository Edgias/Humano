using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeDetailsModel
    {
        public Guid Id { get; set; }

        public Guid SalutationId { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public Gender Gender { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string NationalId { get; set; } = default!;

        public string? Email { get; set; }

        public string Mobile { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public Guid DepartmentId { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; } = default!;

        public Guid? ManagerId { get; set; }

        public string? Manager { get; set; }

        public string CurrentPosition { get; set; } = default!;

        public Address ResidentialAddress { get; set; } = default!;

        public SelectList? Salutations { get; set; }
        public SelectList? Departments { get; set; }
        public SelectList? Managers { get; set; }

        public IEnumerable<EmployeeCheckInModel> CheckIns { get; set; } = Enumerable.Empty<EmployeeCheckInModel>();

        public IEnumerable<EmployeeLeaveModel> Leaves { get; set; } = Enumerable.Empty<EmployeeLeaveModel>();

        public IEnumerable<EmployeeTimesheetModel> Timesheets { get; set; } = Enumerable.Empty<EmployeeTimesheetModel>();

        public IEnumerable<EmployeeWorkExperienceModel> WorkExperiences { get; set; } = Enumerable.Empty<EmployeeWorkExperienceModel>();

        public IEnumerable<EmployeeQualificationModel> Qualifications { get; set; } = Enumerable.Empty<EmployeeQualificationModel>();
    }
}
