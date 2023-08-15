using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.LeaveCategories;

namespace Edgias.Humano.WebApp.Services
{
    public class LeaveCategoryService : ILeaveCategoryService
    {
        private readonly IAsyncRepository<LeaveCategory> _repository;

        public LeaveCategoryService(IAsyncRepository<LeaveCategory> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            LeaveCategory leaveCategory = new(model.Name, model.Allocation);

            await _repository.AddAsync(leaveCategory);
        }

        public async Task<IEnumerable<LeaveCategoryIndexModel>> GetAll()
        {
            IReadOnlyList<LeaveCategory> leaveCategorys = await _repository.GetAllAsync();

            return leaveCategorys.Select(d => new LeaveCategoryIndexModel()
            {
                Id = d.Id,
                Name = d.Name,
                Allocation = d.Allocation
            });
        }

    }
}
