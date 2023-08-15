using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IEmployeeQualificationService
    {
        Task Create(NewQualificationModel model);

    }
}
