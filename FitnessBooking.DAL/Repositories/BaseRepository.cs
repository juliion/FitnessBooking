using System.Linq.Expressions;
using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FitnessBooking.DAL.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(IOptions<DbSettings> settings)
    {
        _context = new AppDbContext(settings);
    }
    
    public IQueryable<TEntity> AsQueryable()
    {
        return _context.GetCollection<TEntity>().AsQueryable();
    }

    public IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filterExpression)
    {
        return _context.GetCollection<TEntity>()
            .Find(filterExpression)
            .ToEnumerable();
    }

    public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return await _context.GetCollection<TEntity>()
            .Find(filterExpression)
            .FirstOrDefaultAsync();
    }

    public async Task<TEntity> FindByIdAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
        return await _context.GetCollection<TEntity>()
            .Find(filter)
            .FirstOrDefaultAsync();
    }

    public async Task InsertOneAsync(TEntity item)
    {
        await _context.GetCollection<TEntity>()
            .InsertOneAsync(item);
    }

    public async Task InsertManyAsync(ICollection<TEntity> items)
    {
        await _context.GetCollection<TEntity>()
            .InsertManyAsync(items);
    }

    public async Task ReplaceOneAsync(TEntity item)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, item.Id);
        await _context.GetCollection<TEntity>()
            .FindOneAndReplaceAsync(filter, item);
    }
    public async Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        await _context.GetCollection<TEntity>()
            .FindOneAndDeleteAsync(filterExpression);
    }

    public async Task DeleteByIdAsync(string id)
    {
        await _context.GetCollection<TEntity>()
            .DeleteOneAsync(Builders<TEntity>.Filter.Eq(e => e.Id, id));
    }

    public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        await _context.GetCollection<TEntity>()
            .DeleteManyAsync(filterExpression);
    }
}