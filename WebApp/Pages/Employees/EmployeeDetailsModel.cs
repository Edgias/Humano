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

        public IEnumerable<EmployeeCheckInModel> CheckIns { get; set; } 

        public IEnumerable<EmployeeIndexModel> DirectReports { get; set; }

        public IEnumerable<EmployeeLeaveModel> Leaves { get; set; }

        public IEnumerable<EmployeeTimesheetModel> Timesheets { get; set; }

        public IEnumerable<EmployeeWorkExperienceModel> WorkExperiences { get; set; }

        public IEnumerable<EmployeeQualificationModel> Qualifications { get; set; }

        public EmployeeDetailsModel()
        {
            CheckIns = Enumerable.Empty<EmployeeCheckInModel>();
            DirectReports = Enumerable.Empty<EmployeeIndexModel>();
            Leaves = Enumerable.Empty<EmployeeLeaveModel>();
            Timesheets = Enumerable.Empty<EmployeeTimesheetModel>();
            WorkExperiences = Enumerable.Empty<EmployeeWorkExperienceModel>();
            Qualifications = Enumerable.Empty<EmployeeQualificationModel>();
        }
    }
}
