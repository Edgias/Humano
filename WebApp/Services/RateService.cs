using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Rates;

namespace Edgias.Humano.WebApp.Services
{
    public class RateService : IRateService
    {
        private readonly IAsyncRepository<Rate> _repository;

        public RateService(IAsyncRepository<Rate> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Rate rate = new(model.Name, model.Amount);

            await _repository.AddAsync(rate);
        }

        public async Task<IEnumerable<RateIndexModel>> GetAll()
        {
            IReadOnlyList<Rate> rates = await _repository.GetAllAsync();

            return rates.Select(r => new RateIndexModel()
            {
                Id = r.Id,
                Name = r.Name,
                Amount = r.Amount
            });
        }
    }
}
