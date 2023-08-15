namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeWorkExperienceModel
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Salary { get; set; }

        public string JobTitle { get; set; } = string.Empty;

    }
}
