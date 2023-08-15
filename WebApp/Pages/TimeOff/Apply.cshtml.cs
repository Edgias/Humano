using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.TimeOff
{
    public class ApplyModel : PageModel
    {
        [BindProperty]
        public Guid EmployeeId { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public Guid LeaveCategoryId { get; set; }

        [BindProperty]
        public DateTime? HalfDay { get; set; }

        [BindProperty]
        public HourPeriod HourPeriod { get; set; }

        [BindProperty]
        public string Duration { get; set; } = string.Empty;

        public SelectList? Durations { get; set; }


        public SelectList? LeaveCategories { get; set; }

        private readonly ILeaveCategoryService _leaveCategoryService;

        public ApplyModel(ILeaveCategoryService leaveCategoryService)
        {
            _leaveCategoryService = leaveCategoryService;
        }

        public async Task OnGet(Guid id)
        {
            EmployeeId = id;
            var categories = await _leaveCategoryService.GetAll();
            var durations = new List<string>() { "All Day", "Half Day" };

            LeaveCategories = new SelectList(categories, "Id", "Name");
            Durations = new SelectList(durations.Select(d => new { Id = d, Name = d }), "Id", "Name");
        }
    }
}
