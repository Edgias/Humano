using Edgias.Humano.WebApp.Pages.Rates;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IRateService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<RateIndexModel>> GetAll();
    }
}
