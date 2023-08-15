using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T: BaseEntity, IAggregateRoot
    {
        Task<T> AddAsync(T entity);

        Task AddAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task<int> CountAllAsync();

        Task<int> CountAsync(ISpecification<T> specification);

        Task<T?> FirstOrDefaultAsync(ISpecification<T> specification);

        Task<T?> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> specification);
    }
}
