using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessBooking.DAL.Entities;

public class Booking
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string ClassId { get; set; } = null!;
    public DateTime SessionDate { get; set; }
    public string Status { get; set; } = null!;
    public string PaymentInfo { get; set; } = null!;
    
}