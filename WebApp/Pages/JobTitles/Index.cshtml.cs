using Microsoft.AspNetCore.Mvc.RazorPages;
using Edgias.Humano.WebApp.Interfaces;

namespace Edgias.Humano.WebApp.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        public IEnumerable<JobTitleIndexModel> JobTitles { get; set; }

        private readonly IJobTitleService _jobTitleService;

        public IndexModel(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
            JobTitles = Enumerable.Empty<JobTitleIndexModel>();
        }

        public async Task OnGetAsync()
        {
            JobTitles = await _jobTitleService.GetAll();
        }
    }
}
