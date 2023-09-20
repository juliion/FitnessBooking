namespace FitnessBooking.BLL.DTOs.Instructors.Requests;

public class CreateInstructorDTO
{
    public string? UserId { get; set; } 
    public string Bio { get; set; } 
    public string ContactInfo { get; set; }
    public List<string> Certifications = new();
}