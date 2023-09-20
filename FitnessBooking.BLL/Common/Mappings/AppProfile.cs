using AutoMapper;
using FitnessBooking.BLL.DTOs.FitnessClasses.Requests;
using FitnessBooking.BLL.DTOs.FitnessClasses.Responses;
using FitnessBooking.BLL.DTOs.Instructors.Requests;
using FitnessBooking.BLL.DTOs.Instructors.Responses;
using FitnessBooking.BLL.DTOs.Roles.Requests;
using FitnessBooking.BLL.DTOs.Roles.Responses;
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
        
        CreateMap<CreateRoleDTO, Role>();
        CreateMap<Role, RoleDTO>();
        
        CreateMap<CreateClassDTO, FitnessClass>();
        CreateMap<UpdateClassDTO, FitnessClass>();
        CreateMap<FitnessClass, FitnessClassDTO>();
        
        CreateMap<CreateInstructorDTO, Instructor>();
        CreateMap<UpdateInstructorDTO, Instructor>();
        CreateMap<Instructor, InstructorDTO>();

    }
    
}