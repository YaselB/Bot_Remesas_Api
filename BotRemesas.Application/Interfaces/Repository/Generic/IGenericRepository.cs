using BotRemesas.Domain.Entities.Generic;

namespace BotRemesas.Application.Interfaces.Repository.Generic;
public interface IGenericRepository<T> where T : GenericEntity<T>
{
    public Task<T> AddAsync(T entity , CancellationToken cancellationToken = default);
    public Task<T?> Update(T entity , CancellationToken cancellationToken = default);
    public Task Delete(T entity , CancellationToken cancellationToken = default);
    public Task<T?> GetById(string id , CancellationToken cancellationToken = default);
    public Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);
}