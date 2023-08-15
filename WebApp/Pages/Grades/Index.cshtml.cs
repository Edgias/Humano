using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.Grades
{
    public class IndexModel : PageModel
    {
        public IEnumerable<GradeIndexModel> Grades { get; set; }

        private readonly IGradeService _gradeService;

        public IndexModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
            Grades = Enumerable.Empty<GradeIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Grades = await _gradeService.GetAll();
        }
    }
}
