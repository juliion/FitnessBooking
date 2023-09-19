namespace FitnessBooking.BLL.DTOs.FitnessClasses.Responses;

public class FitnessClassDTO
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string InstructorId { get; set; } = null!;
    public List<DateTime> Schedule { get; set; } = new();
    public int MaxCapacity { get; set; }
    public decimal Price { get; set; }
    
}