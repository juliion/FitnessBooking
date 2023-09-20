using FitnessBooking.BLL.DTOs.Users.Responses;

namespace FitnessBooking.BLL.DTOs.Instructors.Responses;

public class InstructorDTO
{
    public string Id { get; set; } = null!;
    public UserDTO User { get; set; }
    public string Bio { get; set; } 
    public string ContactInfo { get; set; }
    public List<string> Certifications = new();
}