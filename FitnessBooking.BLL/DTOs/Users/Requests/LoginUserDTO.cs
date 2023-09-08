namespace FitnessBooking.BLL.DTOs.Users.Requests;

public class LoginUserDTO
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}