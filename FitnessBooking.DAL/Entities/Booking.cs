using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("Bookings")] 
public class Booking : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string ClassId { get; set; } = null!;
    public DateTime SessionDate { get; set; }
    public string Status { get; set; } = null!;
    public string PaymentInfo { get; set; } = null!;
    
}