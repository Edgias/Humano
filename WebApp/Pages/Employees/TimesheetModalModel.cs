using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class TimesheetModalModel
    {
        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int NumberOfHours { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        public Guid? ProjectId { get; set; }

        public SelectList? Projects { get; set; }
    }
}
