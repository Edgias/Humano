using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int Duration { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        private readonly List<Timesheet> _timesheets = new();
        public IReadOnlyCollection<Timesheet> Timesheets => _timesheets.AsReadOnly();

        public Project(string name, string description, int duration,
            DateTime startDate, DateTime? endDate)
        {
            Name = name;
            Description = description;
            Duration = duration;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Project(string name, string description, int duration,
            DateTime startDate, DateTime? endDate, List<Timesheet> timesheets)
        {
            Name = name;
            Description = description;
            Duration = duration;
            StartDate = startDate;
            EndDate = endDate;
            _timesheets = timesheets;
        }

        public int TimeTaken()
        {
            int timeTaken = 0;

            if(_timesheets != null && _timesheets.Any()) 
            { 
                foreach(var timesheet in _timesheets) 
                {
                    timeTaken += timesheet.NumberOfHours;
                }
            }

            return timeTaken;
        }

        public int DurationInHours()
        {
            return Duration * 24;
        }

        public decimal PercentageComplete()
        {
            int timeTaken = TimeTaken();
            int duration = DurationInHours();
            decimal t = (decimal)timeTaken / (decimal)duration;
            return Math.Round(t * 100, 2);
        }
    }
}
