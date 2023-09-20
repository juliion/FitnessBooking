using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("Instructors")]
public class Instructor : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string ContactInfo { get; set; } = null!;
    public List<string> Certifications = new();
}