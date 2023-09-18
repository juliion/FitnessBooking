using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("Roles")]
public class Role : BaseEntity
{
    public string Name { get; set; } = null!;
}