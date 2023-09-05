using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("Reviews")]
public class Review : BaseEntity
{
    public string ClassId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
}