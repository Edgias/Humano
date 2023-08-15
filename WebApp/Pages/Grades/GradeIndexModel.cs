namespace Edgias.Humano.WebApp.Pages.Grades
{
    public class GradeIndexModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal MinimumSalary { get; set; }

        public decimal MaximumSalary { get; set; }

    }
}
