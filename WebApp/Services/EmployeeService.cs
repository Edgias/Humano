using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.ApplicationCore.Specifications;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAsyncRepository<CheckIn> _checkInRepository;
        private readonly IAsyncRepository<Employee> _repository;
        private readonly IAsyncRepository<Timesheet> _timesheetRepository;
        private readonly ILeaveService _leaveService;
        
        public EmployeeService(IAsyncRepository<CheckIn> checkInRepository,
            IAsyncRepository<Employee> repository,
            IAsyncRepository<Timesheet> timesheetRepository,
            ILeaveService leaveService)
        {
            _checkInRepository = checkInRepository;
            _repository = repository;
            _timesheetRepository = timesheetRepository;
            _leaveService = leaveService;
        }

        public async Task AddCheckIn(CheckInModalModel model)
        {
            CheckIn checkIn = new(model.Date, model.TimeIn, model.TimeOut, model.EmployeeId);

            await _checkInRepository.AddAsync(checkIn);
        }

        public async Task AddLeave(LeaveModalModel model)
        {
            await _leaveService.AddLeave(model);
        }

        public async Task AddQualification(QualificationModalModel model)
        {
            Employee? employee = await _repository.GetByIdAsync(model.EmployeeId);
            EmployeeQualification qualification = new(model.Level, model.School, model.Grade,
                model.FieldOfStudy, model.StartDate, model.EndDate);

            if (employee is not null)
            {
                employee.AddQualification(qualification);

                await _repository.UpdateAsync(employee);
            }
        }

        public async Task AddTimesheet(TimesheetModalModel model)
        {
            Timesheet timesheet = new(model.Description, model.Date, model.NumberOfHours, model.EmployeeId);

            await _timesheetRepository.AddAsync(timesheet);
        }

        public async Task AddWorkExperience(WorkExperienceModalModel model)
        {
            Employee? employee = await _repository.GetByIdAsync(model.EmployeeId);
            WorkExperience workExperience = new(model.Salary, model.StartDate, model.EndDate,
                model.JobTitleId, model.EmployeeId, model.GradeId);

            if(employee is not null) 
            {
                employee.AddWorkExperience(workExperience);

                await _repository.UpdateAsync(employee);
            }
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
            Employee? employee = await _repository.FirstOrDefaultAsync(new EmployeeDetailsSpecification(id));

            return new EmployeeDetailsModel()
            {
                Id = employee!.Id,
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
                    Salary = we.Salary
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
