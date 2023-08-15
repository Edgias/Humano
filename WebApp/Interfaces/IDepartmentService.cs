using Edgias.Humano.WebApp.Pages.Departments;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IDepartmentService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<DepartmentIndexModel>> GetAll();
    }
}
