using FitnessBooking.DAL.Atributes;
using FitnessBooking.DAL.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessBooking.DAL;

public class AppDbContext
{
    private readonly IMongoDatabase _db;

    public AppDbContext(IOptions<DbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _db = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        var collectionName = GetCollectionName(typeof(T));
        return _db.GetCollection<T>(collectionName);
    }

    private string GetCollectionName(Type entityType)
    {
        var attribute = entityType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
            .FirstOrDefault() as BsonCollectionAttribute;

        return attribute?.CollectionName ?? entityType.Name;
    }
}