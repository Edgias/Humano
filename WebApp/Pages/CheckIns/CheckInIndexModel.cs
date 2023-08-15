namespace Edgias.Humano.WebApp.Pages.CheckIns
{
    public class CheckInIndexModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string TimeIn { get; set; } = string.Empty;

        public string? TimeOut { get; set; }

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;
    }
}
