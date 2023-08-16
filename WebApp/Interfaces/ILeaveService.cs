using Edgias.Humano.WebApp.Pages.Employees;
using Edgias.Humano.WebApp.Pages.TimeOff;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface ILeaveService
    {
        Task<(bool isCreated, string message)> AddLeave(LeaveModalModel model);

        Task<(bool isCreated, string message)> AddLeave(ApplyModel model);

        Task<IEnumerable<TimeOffIndexModel>> GetAll();

        Task<IEnumerable<TimeOffIndexModel>> GetAllRequiringMyApproval();


    }
}
