using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("Users")]
public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public List<string> Roles { get; set; } = new();
}