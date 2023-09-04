using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessBooking.DAL.Entities;

public class Instructor
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string ContactInfo { get; set; } = null!;
}