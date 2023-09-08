using AutoMapper;
using FitnessBooking.BLL.DTOs.Users.Requests;
using FitnessBooking.BLL.DTOs.Users.Responses;
using FitnessBooking.DAL.Entities;

namespace FitnessBooking.BLL.Common.Mappings;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<LoginUserDTO, User>();
        CreateMap<User, UserDTO>();
    }
    
}