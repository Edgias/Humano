using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class CalendarSetting : BaseEntity, IAggregateRoot
    {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public CalendarSetting(int day, int month)
        {
            Day = day;
            Month = month;
        }
    }
}
