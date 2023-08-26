using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.UnitTests.Builders
{
    public class TimesheetBuilder
    {
        private Timesheet _timesheet;

        private static string TestDescription => "Test description";
        private static DateTime Date => new(2023, 08, 21);
        private static int NumberOfHours => 800;
        private static Guid EmployeeId => new("c3003cde-07b2-4249-70c6-08d83d0df748");


        public TimesheetBuilder()
        {
            _timesheet = WithDefaultValues();
        }

        public Timesheet Build()
        {
            return _timesheet;
        }

        public Timesheet WithDefaultValues()
        {
            _timesheet = new Timesheet(TestDescription, Date, NumberOfHours, EmployeeId, null);
            
            return _timesheet;
        }

        public List<Timesheet> GetCollection()
        {
            List<Timesheet> timesheets = new()
            {
                new Timesheet(TestDescription, new DateTime(2023, 08, 22), 18, EmployeeId, null),
                new Timesheet(TestDescription, new DateTime(2023, 08, 22), 120, EmployeeId, null),
                new Timesheet(TestDescription, new DateTime(2023, 08, 22), 800, EmployeeId, null)
            };

            return timesheets;
        }
    }
}
