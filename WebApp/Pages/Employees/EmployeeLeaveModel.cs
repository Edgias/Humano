using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeLeaveModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveStatus LeaveStatus { get; set; }

        public string LeaveCategory { get; set; } = string.Empty;
    }
}
