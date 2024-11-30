﻿namespace App.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task RemoveAsync(T entity);
    Task UpdateAsync(T entity);
}
