using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class CheckIn : BaseEntity, IAggregateRoot
    {
        public DateTime Date { get; private set; }

        public string TimeIn { get; private set; } = string.Empty;

        public string? TimeOut { get; private set; }

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = null!;

        public CheckIn(DateTime date, string timeIn, string? timeOut, Guid employeeId)
        {
            Date = date;
            TimeIn = timeIn;
            TimeOut = timeOut;
            EmployeeId = employeeId;
        }

        public void Checkout()
        {
            if(string.IsNullOrEmpty(TimeOut)) 
            {
                TimeOut = $"{DateTime.Now:HH:mm:ss t}";
            }
        }
    }
}
