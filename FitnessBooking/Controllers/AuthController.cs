using FitnessBooking.BLL.DTOs.Users.Requests;
using FitnessBooking.BLL.DTOs.Users.Responses;
using FitnessBooking.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    } 
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var user = await _authService.GetUserAsync(id);
        
        return Ok(user);
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDTO newUser)
    {
        await _authService.CreateAsync(newUser);
        
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDTO userDto)
    {
        var token = await _authService.AuthenticateAsync(userDto);

        if (token == null)
        {
            return Unauthorized();
        }
        
        return Ok(new { token });
    }
}