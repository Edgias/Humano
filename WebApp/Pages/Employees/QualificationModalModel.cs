using Edgias.Humano.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class QualificationModalModel
    {
        [Required]
        public string School { get; set; } = default!;

        [Required]
        public QualificationLevel Level { get; set; }

        [Required]
        public string FieldOfStudy { get; set; } = default!;

        [Required]
        public string Grade { get; set; } = default!;

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}
