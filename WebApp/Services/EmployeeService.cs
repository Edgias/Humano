using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.ApplicationCore.Specifications;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAsyncRepository<Employee> _repository;
        
        public EmployeeService(IAsyncRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task AddExperience(NewWorkExperienceModel model)
        {
            WorkExperience workExperience = new(model.Salary, model.StartDate, model.EndDate, model.JobTitleId,
                model.EmployeeId, model.GradeId);

            Employee employee = await _repository.GetByIdAsync(model.EmployeeId);

            employee.AddWorkExperience(workExperience);

            await _repository.UpdateAsync(employee);
        }

        public async Task AddWorkExperience(WorkExperienceModalModel model)
        {
            var employee = await _repository.GetByIdAsync(model.EmployeeId);
            WorkExperience workExperience = new(model.Salary, model.StartDate, model.EndDate,
                model.JobTitleId, model.EmployeeId, model.GradeId);

            employee.AddWorkExperience(workExperience);

            await _repository.UpdateAsync(employee);
        }

        public async Task Create(CreateModel model)
        {
            Address address = new(model.Street, model.City, model.State, model.Country);
            Employee employee = new(model.SalutationId, model.FirstName, model.LastName, model.Gender
                , model.EmployeeType,model.NationalId,model.Mobile,model.Email,model.DateOfBirth,
                model.DateJoined,model.DepartmentId,null,address);

            await _repository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeIndexModel>> GetAll()
        {
            IReadOnlyList<Employee> employees = await _repository.GetAsync(new EmployeeDetailsSpecification());

            return employees.Select(e => new EmployeeIndexModel() 
            { 
                Id = e.Id,
                Email = e.Email,
                NationalId = e.NationalId,
                DateJoined = e.DateJoined,
                Age = e.Age(),
                DateOfBirth = e.DateOfBirth,
                Department = e.Department.Name,
                Mobile = e.Mobile,
                Salutation = e.Salutation.Name,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Manager = $"{e.Manager?.FirstName} {e.Manager?.LastName}"
            });
        }

        public async Task<EmployeeDetailsModel> GetEmployeeWithAllDetailsById(Guid id)
        {
            var employee = await _repository.FirstOrDefaultAsync(new EmployeeDetailsSpecification(id));

            return new EmployeeDetailsModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                NationalId = employee.NationalId,
                DateJoined = employee.DateJoined,
                DateOfBirth = employee.DateOfBirth,
                Age = employee.Age(),
                Department = employee.Department.Name,
                Email = employee.Email,
                Mobile = employee.Mobile,
                Manager = $"{employee.Manager?.FirstName} {employee.Manager?.LastName}",
                ResidentialAddress = employee.ResidentialAddress,
                CheckIns = employee.CheckIns.Select(c => new EmployeeCheckInModel()
                {
                    Date = c.Date,
                    TimeIn = c.TimeIn,
                    TimeOut = c.TimeOut
                }),
                Qualifications = employee.EmployeeQualifications.Select(q => new EmployeeQualificationModel()
                {
                    EndDate = q.EndDate,
                    StartDate = q.StartDate,
                    FieldOfStufy = q.FieldOfStudy,
                    School = q.School,
                    Grade = q.Grade,
                    Level = q.Level
                }),
                Timesheets = employee.Timesheets.Select(t => new EmployeeTimesheetModel()
                {
                    Date = t.Date,
                    Description = t.Description,
                    NumberOfHours = t.NumberOfHours,
                }),
                WorkExperiences = employee.WorkExperiences.Select(we => new EmployeeWorkExperienceModel()
                {
                    EndDate = we.EndDate,
                    StartDate = we.StartDate,
                    JobTitle = we.JobTitle.Name,
                    Salary = 0
                }),
                Leaves = employee.Leaves.Select(l => new EmployeeLeaveModel()
                {
                    LeaveCategory = l.LeaveCategory.Name,
                    EndDate = l.EndDate,
                    StartDate = l.StartDate,
                    LeaveStatus = l.LeaveStatus,
                }),
                CurrentPosition = employee.CurrentPosition(),
                Salary = employee.CurrentSalary()
            };
        }
    }
}
