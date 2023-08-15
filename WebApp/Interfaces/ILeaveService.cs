using Edgias.Humano.WebApp.Pages.TimeOff;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ILeaveService
    {
        Task<(bool isCreated, string message)> Apply(ApplyModel model);

        Task<IEnumerable<TimeOffIndexModel>> GetAll();

        Task<IEnumerable<TimeOffIndexModel>> GetAllRequiringMyApproval();


    }
}
