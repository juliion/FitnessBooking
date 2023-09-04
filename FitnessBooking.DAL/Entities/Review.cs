using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessBooking.DAL.Entities;

public class Review
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string ClassId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
}