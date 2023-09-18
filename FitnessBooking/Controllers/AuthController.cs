using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.Roles.Requests;
using FitnessBooking.BLL.DTOs.Users.Requests;
using FitnessBooking.BLL.DTOs.Users.Responses;
using FitnessBooking.BLL.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IRoleService _roleService;
    private readonly IValidator<LoginUserDTO> _loginValidator;
    private readonly IValidator<CreateUserDTO> _createUserValidator;

    public AuthController(IAuthService authService, IValidator<LoginUserDTO> loginValidator, IValidator<CreateUserDTO> createUserValidator, IRoleService roleService)
    {
        _authService = authService;
        _roleService = roleService;
        _loginValidator = loginValidator;
        _createUserValidator = createUserValidator;
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
        var validationRes = _createUserValidator.Validate(newUser);
        if (!validationRes.IsValid)
            return BadRequest(validationRes);

        string id = "";
        try
        {
            id = await _authService.CreateAsync(newUser);
            
            await _roleService.AssignRoleToUser(new AssignRoleDTO
            {
                UserId = id, 
                Role = "user"
            });
        }
        catch (ConflictException e)
        {
            return Conflict(new {e.Message});
        }
        
        return Ok(id);
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDTO userDto)
    {
        var validationRes = _loginValidator.Validate(userDto);
        if (!validationRes.IsValid)
            return BadRequest(validationRes);
        
        var token = await _authService.AuthenticateAsync(userDto);

        if (token == null)
        {
            return Unauthorized();
        }
        
        return Ok(new { token });
    }
}