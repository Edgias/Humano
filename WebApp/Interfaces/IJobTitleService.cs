using Edgias.Humano.WebApp.Pages.JobTitles;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IJobTitleService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<JobTitleIndexModel>> GetAll();
    }
}
