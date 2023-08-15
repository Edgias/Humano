using Edgias.Humano.WebApp.Pages.LeaveCategories;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ILeaveCategoryService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<LeaveCategoryIndexModel>> GetAll();
    }
}
