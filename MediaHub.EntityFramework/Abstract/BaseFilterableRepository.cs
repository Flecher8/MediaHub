using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.EntityFramewok.Abstract;
// A base repository class that supports filtering and dynamic includes for any entity type
public abstract class BaseFilterableRepository<T> : BaseRepository<T>, IFilterableRepository<T>
    where T : class
{
    // An instance of the generic filter builder.
    protected readonly BaseFilterBuilder<T> _filterBuilder;

    // Constructor accepting the database context and initializing the filter builder.
    public BaseFilterableRepository(DataContext dbContext, BaseFilterBuilder<T> filterBuilder) : base(dbContext)
    {
        _filterBuilder = filterBuilder;
    }

    // Method to get filtered items based on the provided filter configuration.
    public virtual async Task<List<T>> GetFilteredItemsAsync(Action<BaseFilterBuilder<T>> buildFilter)
    {
        // Apply the filter configuration.
        buildFilter(_filterBuilder);

        // Start building the query for the entity set.
        var query = _dbContext.Set<T>().AsQueryable();

        // Include related entities based on the configured includes.
        query = IncludeEntities(query);

        // Apply the filter expression to the query.
        var filter = _filterBuilder.Filter;

        // Execute the query and return the results as a list.
        return await query
            .Where(filter)
            .ToListAsync();
    }

    // Method to apply include expressions to the query dynamically.
    protected virtual IQueryable<T> IncludeEntities(IQueryable<T> query)
    {
        // Iterate through all include expressions and apply them to the query.
        foreach (var include in _filterBuilder.GetIncludes())
        {
            query = query.Include(include);
        }
        return query;
    }
}
