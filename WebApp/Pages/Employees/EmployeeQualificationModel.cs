using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeQualificationModel
    {
        public string School { get; set; } = string.Empty;

        public QualificationLevel Level { get; set; }

        public string FieldOfStufy { get; set; } = string.Empty;

        public string Grade { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
