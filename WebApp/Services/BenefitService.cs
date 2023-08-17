using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.Benefits;

namespace Edgias.Humano.WebApp.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IAsyncRepository<Benefit> _repository;

        public BenefitService(IAsyncRepository<Benefit> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            Benefit benefit = new(model.Name, model.EmployeeDeduction, model.CompanyContribution);

            await _repository.AddAsync(benefit);
        }

        public async Task<IEnumerable<BenefitIndexModel>> GetAll()
        {
            var benefits = await _repository.GetAllAsync();

            return benefits.Select(b => new BenefitIndexModel 
            {  
                Id = b.Id,
                Name = b.Name, 
                EmployeeDeduction = b.EmployeeDeduction, 
                CompanyContribution = b.CompanyContribution 
            });
        }
    }
}
