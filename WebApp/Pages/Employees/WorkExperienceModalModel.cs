using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class WorkExperienceModalModel
    {
        [Required]
        public decimal Salary { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        [Required]
        public Guid GradeId { get; set; }

        [Required]
        public Guid JobTitleId { get; set; }

        public SelectList? JobTitles { get; set; }

        public SelectList? Grades { get; set; }

    }
}
