namespace FitnessBooking.BLL.DTOs.Instructors.Requests;

public class UpdateInstructorDTO
{
    public string Bio { get; set; } 
    public string ContactInfo { get; set; }
    public List<string> Certifications = new();
}