using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Projects
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ProjectIndexModel> Projects { get; set; }

        private readonly IProjectService _projectService;

        public IndexModel(IProjectService projectService)
        {
            _projectService = projectService;
            Projects = Enumerable.Empty<ProjectIndexModel>();
        }

        public async Task OnGetAsync()
        {
            Projects = await _projectService.GetAll();
        }
    }
}
