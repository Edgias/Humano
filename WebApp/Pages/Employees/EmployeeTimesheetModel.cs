namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeTimesheetModel
    {
        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int NumberOfHours { get; set; }
    }
}
