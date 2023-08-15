namespace Edgias.Humano.WebApp.Pages.TimeOff
{
    public class TimeOffIndexModel
    {
        public Guid Id { get; set; }

        public string Employee { get; set; } = default!;

        public Guid EmployeeId { get; set; }

        public DateTime DateSubmitted { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int NumberOfDays { get; set; }

        public string LeaveCategory { get; set; } = default!;

        public string LeaveStatus { get; set; } = default!;
    }
}
