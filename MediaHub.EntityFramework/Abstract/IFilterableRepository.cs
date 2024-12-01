namespace MediaHub.EntityFramework.Abstract;

public interface IFilterableRepository<T> : IDataRepository<T>
{
    // Method to get filtered items using the generic BaseFilterBuilder<T>.
    Task<List<T>> GetFilteredItemsAsync(Action<BaseFilterBuilder<T>> buildFilter);
}
