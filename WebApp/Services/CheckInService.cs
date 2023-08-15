using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.WebApp.Interfaces;
using Edgias.Humano.WebApp.Pages.CheckIns;

namespace Edgias.Humano.WebApp.Services
{
    public class CheckInService : ICheckInService
    {
        private readonly IAsyncRepository<CheckIn> _repository;

        public CheckInService(IAsyncRepository<CheckIn> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateModel model)
        {
            CheckIn checkIn = new(model.Date, model.TimeIn, model.TimeOut, model.EmployeeId);

            await _repository.AddAsync(checkIn);
        }

        public async Task<IEnumerable<CheckInIndexModel>> GetAll()
        {
            IReadOnlyList<CheckIn> checkIns = await _repository.GetAllAsync();

            return checkIns.Select(d => new CheckInIndexModel()
            {
                Id = d.Id,
                Date = d.Date,
                TimeIn = d.TimeIn,
                TimeOut = d.TimeOut,
                EmployeeId = d.EmployeeId,
                EmployeeName = $"{d.Employee?.FirstName} {d.Employee?.LastName}"
            });
        }

    }
}
