using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.EntityFramewok.Abstract;
public interface IFilterableRepository<T> : IDataRepository<T>
{
    // Method to get filtered items using the generic BaseFilterBuilder<T>.
    Task<List<T>> GetFilteredItemsAsync(Action<BaseFilterBuilder<T>> buildFilter);
}
