using FitnessBooking.DAL.Atributes;

namespace FitnessBooking.DAL.Entities;

[BsonCollection("FitnessClasses")] 
public class FitnessClass : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string InstructorId { get; set; } = null!;
    public string Location { get; set; } = null!;
    public List<DateTime> Schedule { get; set; } = new();
    public int MaxCapacity { get; set; }
    public decimal Price { get; set; }
    public List<string> EquipmentRequired { get; set; } = new();
}