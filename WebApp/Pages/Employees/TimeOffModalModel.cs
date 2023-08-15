using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class TimeOffModalModel
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid LeaveCategoryId { get; set; }

        public DateTime? HalfDay { get; set; }

        public HourPeriod HourPeriod { get; set; }

        public string Duration { get; set; } = default!;

        public SelectList? Durations { get; set; }

        public SelectList? LeaveCategories { get; set; }
    }
}
