using Edgias.Humano.WebApp.Pages.Projects;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IProjectService
    {
        Task Create(CreateModel model);

        Task<ProjectDetailsModel> GetProjectDetails(Guid id);

        Task<IEnumerable<ProjectIndexModel>> GetAll();
    }
}
