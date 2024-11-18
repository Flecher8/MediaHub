using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.EntityFramewok.Abstract;
// Base filter builder that handles filtering and includes for any entity type
public class BaseFilterBuilder<T>
{
    // Holds the main filter expression, defaulting to a filter that always returns true (i.e., no filter).
    public Expression<Func<T, bool>> Filter { get; private set; } = _ => true;

    // A list to store include expressions for related entities (navigation properties).
    private readonly List<Expression<Func<T, object>>> _includes = new List<Expression<Func<T, object>>>();

    // Method to set a custom filter expression.
    public BaseFilterBuilder<T> WithFilter(Expression<Func<T, bool>> filter)
    {
        Filter = filter;
        return this;
    }

    // Method to add an include expression for a related entity.
    // This allows navigation properties to be eagerly loaded.
    public BaseFilterBuilder<T> Include(Expression<Func<T, object>> includeExpression)
    {
        _includes.Add(includeExpression);
        return this;
    }

    // Retrieves the list of include expressions to be used in the repository query.
    public IEnumerable<Expression<Func<T, object>>> GetIncludes()
    {
        return _includes;
    }
}
