using Microsoft.EntityFrameworkCore;
using OmerOzkan.Digiturk.Makale.DataAccess.Context;
using OmerOzkan.Digiturk.Makale.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OmerOzkan.Digiturk.Makale.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new DatabaseContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new DatabaseContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<T>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new DatabaseContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<T>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var context = new DatabaseContext();
            return await context.FindAsync<T>(id);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new DatabaseContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new DatabaseContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
