using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IEmployeeService
    {
        Task Create(CreateModel model);

        Task AddWorkExperience(WorkExperienceModalModel workExperience);

        Task AddExperience(NewWorkExperienceModel model);

        Task<EmployeeDetailsModel> GetEmployeeWithAllDetailsById(Guid id);

        Task<IEnumerable<EmployeeIndexModel>> GetAll();
    }
}
