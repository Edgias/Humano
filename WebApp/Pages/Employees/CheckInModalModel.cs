using System.ComponentModel.DataAnnotations;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class CheckInModalModel
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public string TimeIn { get; set; } = default!;

        public string? TimeOut { get; set; }
    }
}
