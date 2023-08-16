using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class LeaveModalModel
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        [Required]
        public Guid LeaveCategoryId { get; set; }

        public DateTime? HalfDay { get; set; }

        public HourPeriod HourPeriod { get; set; }

        [Required]
        public string Duration { get; set; } = string.Empty;

        public SelectList? Durations { get; set; }

        public SelectList? LeaveCategories { get; set; }
    }
}
