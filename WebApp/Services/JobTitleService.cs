using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.JobTitles;

namespace Edgias.Humano.WebApp.Services
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IAsyncRepository<JobTitle> _repository;

        public JobTitleService(IAsyncRepository<JobTitle> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            JobTitle jobTitle = new(model.Name);

            await _repository.AddAsync(jobTitle);
        }

        public async Task<IEnumerable<JobTitleIndexModel>> GetAll()
        {
            IReadOnlyList<JobTitle> jobTitles = await _repository.GetAllAsync();

            return jobTitles.Select(d => new JobTitleIndexModel()
            {
                Id = d.Id,
                Name = d.Name
            });
        }

    }
}
