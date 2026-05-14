using AutoMapper;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : GenericEntity<T>
{
    private readonly BotRemesasDbContext context;
    private readonly DbSet<T> dbSet;
    public GenericRepository(BotRemesasDbContext dbContext )
    {
        context = dbContext;
        dbSet = context.Set<T>();
    }
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await dbSet.AddAsync(entity ,cancellationToken);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task Delete(T entity, CancellationToken cancellationToken = default)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default)
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetById(string id, CancellationToken cancellationToken = default)
    {
        return await dbSet.FindAsync(new object [] {id}, cancellationToken);
    }

    public virtual async Task<T?> Update(T entity, CancellationToken cancellationToken = default)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}