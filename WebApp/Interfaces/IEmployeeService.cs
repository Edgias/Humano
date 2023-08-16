using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Interfaces
{
    public interface IEmployeeService
    {
        Task AddCheckIn(CheckInModalModel model);

        Task AddLeave(LeaveModalModel model);

        Task AddQualification(QualificationModalModel model);

        Task AddTimesheet(TimesheetModalModel model);

        Task AddWorkExperience(WorkExperienceModalModel model);

        Task Create(CreateModel model);

        Task<IEnumerable<EmployeeIndexModel>> GetAll();

        Task<EmployeeDetailsModel> GetEmployeeWithAllDetailsById(Guid id);
    }
}
