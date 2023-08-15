namespace Edgias.Humano.ApplicationCore.Entities
{
    public class LeaveDay : BaseEntity
    {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public int Year { get; private set; }

        public DayType DayType { get; private set; }

        public HourPeriod HourPeriod { get; private set; }

        public Guid LeaveId { get; private set; }

        public Leave Leave { get; private set; } = null!;

        public LeaveDay(int day, int month, int year, DayType dayType,
            HourPeriod hourPeriod)
        {
            Day = day;
            Month = month;
            Year = year;
            DayType = dayType;
            HourPeriod = hourPeriod;
        }
    }
}
