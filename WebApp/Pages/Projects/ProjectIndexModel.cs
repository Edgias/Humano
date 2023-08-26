namespace Edgias.Humano.WebApp.Pages.Projects
{
    public class ProjectIndexModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int TimeTaken { get; set; }

        public decimal PercentageComplete { get; set; }

        public int Duration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
