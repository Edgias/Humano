using Edgias.Humano.WebApp.Pages.Grades;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IGradeService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<GradeIndexModel>> GetAll();
    }
}
