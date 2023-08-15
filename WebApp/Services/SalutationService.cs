using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Salutations;

namespace Edgias.Humano.WebApp.Services
{
    public class SalutationService : ISalutationService
    {
        private readonly IAsyncRepository<Salutation> _repository;

        public SalutationService(IAsyncRepository<Salutation> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Salutation salutation = new(model.Name);

            await _repository.AddAsync(salutation);
        }

        public async Task<IEnumerable<SalutationIndexModel>> GetAll()
        {
            IReadOnlyList<Salutation> salutations = await _repository.GetAllAsync();

            return salutations.Select(d => new SalutationIndexModel()
            {
                Id = d.Id,
                Name = d.Name
            });
        }

    }
}
