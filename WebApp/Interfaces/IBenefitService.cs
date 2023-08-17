using Edgias.Humano.WebApp.Pages.Benefits;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IBenefitService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<BenefitIndexModel>> GetAll();
    }
}
