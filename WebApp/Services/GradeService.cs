using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Grades;

namespace Edgias.Humano.WebApp.Services
{
    public class GradeService : IGradeService
    {
        private readonly IAsyncRepository<Grade> _repository;

        public GradeService(IAsyncRepository<Grade> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Grade grade = new(model.Name, model.MinimumSalary, model.MaximumSalary);

            await _repository.AddAsync(grade);
        }

        public async Task<IEnumerable<GradeIndexModel>> GetAll()
        {
            IReadOnlyList<Grade> grades = await _repository.GetAllAsync();

            return grades.Select(d => new GradeIndexModel()
            {
                Id = d.Id,
                Name = d.Name,
                MaximumSalary = d.MaximumSalary,
                MinimumSalary = d.MinimumSalary,
            });
        }

    }
}
