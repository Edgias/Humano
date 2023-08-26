using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.UnitTests.Builders
{
    public class ProjectBuilder
    {
        private Project _project;
        private TimesheetBuilder _timesheetBuilder;

        public static string TestName => "Test Project Name";
        public static string TestDescription => "Test project description";
        public static int Duration => 120;
        public static DateTime StartDate => new(2023, 01, 01);
        public static DateTime? EndDate => default!;

        public ProjectBuilder()
        {
            _project = WithDefaultValues();
            _timesheetBuilder = new TimesheetBuilder();
        }

        public Project Build()
        {
            return _project;
        }

        public Project WithDefaultValues()
        {
            _project = new Project(TestName, TestDescription, Duration, 
                StartDate, EndDate);

            return _project;
        }

        public Project WithTimesheets()
        {
            _project = new Project(TestName, TestDescription, Duration,
                StartDate, EndDate, _timesheetBuilder.GetCollection());

            return _project;
        }

    }
}
