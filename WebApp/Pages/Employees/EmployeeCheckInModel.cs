namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeCheckInModel
    {
        public DateTime Date { get; set; }

        public string TimeIn { get; set; } = string.Empty;

        public string? TimeOut { get; set; }

        
    }
}
