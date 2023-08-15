using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeDetailsModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string NationalId { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Mobile { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; } = string.Empty;

        public string? Manager { get; set; }

        public string CurrentPosition { get; set; } = string.Empty;

        public Address ResidentialAddress { get; set; } = null!;

        public IEnumerable<EmployeeCheckInModel> CheckIns { get; set; }

        public IEnumerable<EmployeeLeaveModel> Leaves { get; set; }

        public IEnumerable<EmployeeTimesheetModel> Timesheets { get; set; }

        public IEnumerable<EmployeeWorkExperienceModel> WorkExperiences { get; set; }

        public IEnumerable<EmployeeQualificationModel> Qualifications { get; set; }
    }
}
