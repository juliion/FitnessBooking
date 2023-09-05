using System.Linq.Expressions;
using FitnessBooking.DAL.Entities;
using MongoDB.Driver;

namespace FitnessBooking.DAL.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> AsQueryable();
    IEnumerable<TEntity> FilterBy(
        Expression<Func<TEntity, bool>> filterExpression);
    Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression);
    Task<TEntity> FindByIdAsync(string id);
    Task InsertOneAsync(TEntity item);
    Task InsertManyAsync(ICollection<TEntity> items);
    Task ReplaceOneAsync(TEntity item);
    Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression);
    Task DeleteByIdAsync(string id);
    Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression);
}