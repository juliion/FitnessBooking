namespace FitnessBooking.BLL.DTOs.Users.Requests;

public class CreateUserDTO
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}