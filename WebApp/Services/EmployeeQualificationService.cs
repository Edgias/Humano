using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Employees;

namespace Edgias.Humano.WebApp.Services
{
    public class EmployeeQualificationService : IEmployeeQualificationService
    {
        private readonly IAsyncRepository<Employee> _repository;

        public EmployeeQualificationService(IAsyncRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task Create(NewQualificationModel model)
        {
            EmployeeQualification employeeQualification =
                new(model.Level, model.School, model.Grade, model.FieldOfStudy, model.StartDate, model.EndDate);

            Employee employee = await _repository.GetByIdAsync(model.EmployeeId);

            employee.AddQualification(employeeQualification);

            await _repository.UpdateAsync(employee);
        }

    }
}
