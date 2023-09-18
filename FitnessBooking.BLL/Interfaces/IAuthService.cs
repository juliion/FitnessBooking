using FitnessBooking.BLL.DTOs.Users.Requests;
using FitnessBooking.BLL.DTOs.Users.Responses;

namespace FitnessBooking.BLL.Interfaces;

public interface IAuthService
{
    public Task<string> CreateAsync(CreateUserDTO userDto);
    public Task<UserDTO> GetUserAsync(string id);
    public Task<string> AuthenticateAsync(LoginUserDTO userDto);
}