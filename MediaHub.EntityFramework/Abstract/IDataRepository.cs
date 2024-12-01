using System.Linq.Expressions;

namespace MediaHub.EntityFramework.Abstract;

public interface IDataRepository<T>
{
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetFilteredItemsAsync(Expression<Func<T, bool>> filter);

    Task<T?> GetByIdAsync(string id);

    Task<T> AddAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(string id);
}
