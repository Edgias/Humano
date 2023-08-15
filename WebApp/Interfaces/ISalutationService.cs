using Edgias.Humano.WebApp.Pages.Salutations;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ISalutationService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<SalutationIndexModel>> GetAll();
    }
}
