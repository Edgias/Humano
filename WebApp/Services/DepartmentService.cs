using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Departments;

namespace Edgias.Humano.WebApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Department> _repository;

        public DepartmentService(IAsyncRepository<Department> repository, 
            IAsyncRepository<Employee> employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task Create(CreateModel model)
        {
            Department department = new(model.Name, model.Email);

            await _repository.AddAsync(department);
        }

        public async Task<IEnumerable<DepartmentIndexModel>> GetAll()
        {
            IReadOnlyList<Department> departments = await _repository.GetAllAsync();

            return departments.Select(d => new DepartmentIndexModel() 
            { 
                Id = d.Id,
                Name = d.Name,
                Email = d.Email
            });
        }

    }
}
