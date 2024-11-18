﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.EntityFramewok.Abstract;
public interface IDataRepository<T>
{
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetFilteredItemsAsync(Expression<Func<T, bool>> filter);

    Task<T?> GetByIdAsync(string id);

    Task<T> AddAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(string id);
}
