using Edgias.Humano.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Edgias.Humano.WebApp.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        public ProjectDetailsModel Project { get; set; } = default!;

        private readonly IProjectService _projectService;

        public DetailsModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task OnGetAsync(Guid id)
        {
            Project = await _projectService.GetProjectDetails(id);
        }
    }
}
