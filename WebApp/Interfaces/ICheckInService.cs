using Edgias.Humano.WebApp.Pages.CheckIns;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ICheckInService
    {
        Task Create(CreateModel model);

        Task<IEnumerable<CheckInIndexModel>> GetAll();
    }
}
