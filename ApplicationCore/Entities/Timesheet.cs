using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Timesheet : BaseEntity, IAggregateRoot
    {
        public string Description { get; private set; } = string.Empty;

        public DateTime Date { get; private set; }

        public int NumberOfHours { get; private set; }

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = null!;

        public Timesheet(string description, DateTime date, int numberOfHours,
            Guid employeeId)
        {
            Description = description;
            Date = date;
            NumberOfHours = numberOfHours;
            EmployeeId = employeeId;
        }
    }
}
