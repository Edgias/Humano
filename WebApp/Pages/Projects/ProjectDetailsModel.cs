using Edgias.Humano.WebApp.Pages.Timesheets;

namespace Edgias.Humano.WebApp.Pages.Projects
{
    public class ProjectDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int TimeTaken { get; set; }

        public int Duration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public IEnumerable<TimesheetIndexModel> Timesheets { get; set; }

        public ProjectDetailsModel()
        {
            Timesheets = Enumerable.Empty<TimesheetIndexModel>();
        }
    }
}
