using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.ApplicationCore.Specifications;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Projects;

namespace Edgias.Humano.WebApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IAsyncRepository<Project> _repository;

        public ProjectService(IAsyncRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Project project = new(model.Name, model.Description, model.Duration, 
                model.StartDate, model.EndDate);

            await _repository.AddAsync(project);
        }

        public async Task<IEnumerable<ProjectIndexModel>> GetAll()
        {
            IReadOnlyList<Project> projects = await _repository.GetAsync(new ProjectSpecification());

            return projects.Select(p => new ProjectIndexModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Duration = p.Duration,
                TimeTaken = p.TimeTaken(),
                PercentageComplete = p.PercentageComplete()
            });
        }

        public async Task<ProjectDetailsModel> GetProjectDetails(Guid id)
        {
            Project? project = await _repository.FirstOrDefaultAsync(new ProjectSpecification(id));

            if(project is not null)
            {
                return new ProjectDetailsModel()
                {
                    Id = id,
                    Name = project.Name,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Duration = project.Duration,
                    TimeTaken = project.Timesheets.Sum(t => t.NumberOfHours),
                    Timesheets = project.Timesheets.Select(t => new Pages.Timesheets.TimesheetIndexModel() 
                    { 
                        Id = t.Id,
                        Date = t.Date,
                        DayOfWeek = t.Date.ToString("dddd"),
                        Description = t.Description,
                        NumberOfHours = t.NumberOfHours,
                        Employee = $"{t.Employee.FirstName} {t.Employee.LastName}",
                        EmployeeId = t.EmployeeId,
                    })
                };
            }

            return default!;
        }
    }
}
