using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;
using TodoApi.Domain.Repositories.Exceptions;
using TodoApi.Infrastructure.Data.Context;
using TodoApi.Infrastructure.Data.Helpers;

namespace TodoApi.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public TodoContext Context { get; }

        public BaseRepository(TodoContext context) => Context = context;

        public async virtual Task InsertAsync(T entity)
        {
            EntityHelper.EnsureNotNull(entity);

            entity.CreatedAt = DateTime.Now;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async virtual Task<T> GetByIdAsync(int? id)
        {
            EntityHelper.EnsureNotNull(id);

            return await Context.Set<T>().FirstOrDefaultAsync(prop => prop.Id == id) ?? throw new NotFoundException();
        }

        public async virtual Task<IEnumerable<T>> GetAll() => await Context.Set<T>().ToListAsync();

        public async virtual Task UpdateAsync(int? id, T entity)
        {
            T retrievedEntity = await GetByIdAsync(id);

            EntityHelper.EnsureNotNull(entity);
            entity.Id = id.Value;
            entity.CreatedAt = retrievedEntity.CreatedAt;

            Context.Entry(retrievedEntity).State = EntityState.Detached;

            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async virtual Task RemoveAsync(int? id)
        {
            T entity = await GetByIdAsync(id);
            EntityHelper.EnsureNotNull(entity);

            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
