namespace Edgias.Humano.WebApp.Pages.Timesheets
{
    public class TimesheetIndexModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string DayOfWeek { get; set; } = string.Empty;

        public int NumberOfHours { get; set; }

        public Guid EmployeeId { get; set; }

        public string Employee { get; set; } = string.Empty;
    }
}
