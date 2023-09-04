using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessBooking.DAL.Entities;

public class FitnessClass
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string InstructorId { get; set; } = null!;
    public string Location { get; set; } = null!;
    public List<DateTime> Schedule { get; set; } = new();
    public int MaxCapacity { get; set; }
    public decimal Price { get; set; }
    public List<string> EquipmentRequired { get; set; } = new();
}