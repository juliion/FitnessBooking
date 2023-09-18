using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.Users.Requests;
using FitnessBooking.BLL.DTOs.Users.Responses;
using FitnessBooking.BLL.Interfaces;
using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessBooking.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public AuthService(IUserRepository usersRepository, IMapper mapper, IConfiguration config)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _config = config;
    }
    
    public async Task CreateAsync(CreateUserDTO userDto)
    {
        var user = await _usersRepository.FindOneAsync(u => u.Email == userDto.Email);
        if (user != null)
        {
            throw new ConflictException("User with that e-mail address already exists");
        }
        var newUser = _mapper.Map<CreateUserDTO, User>(userDto);

        newUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        
        await _usersRepository.InsertOneAsync(newUser);
    }

    public async Task<UserDTO> GetUserAsync(string id)
    {
        var user = await _usersRepository.FindByIdAsync(id);
        
        var userDto = _mapper.Map<User, UserDTO>(user);
        
        return userDto;
    }

    public async Task<string> AuthenticateAsync(LoginUserDTO userDto)
    {
        var user = await _usersRepository
            .FindOneAsync(u => u.Email == userDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
        {
            return null;
        }
        
        var token = CreateToken(userDto.Email, user.Roles);
        
        return token;
    }

    private string CreateToken(string email, List<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = _config.GetSection("JwtKey").ToString();
        var tokenKey = Encoding.ASCII.GetBytes(key);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
        };
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}