using AutoMapper;
using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.Roles.Requests;
using FitnessBooking.BLL.DTOs.Roles.Responses;
using FitnessBooking.BLL.Interfaces;
using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;

namespace FitnessBooking.BLL.Services;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Role> _rolesRepository;
    private readonly IUserRepository _usersRepository;

    public RoleService(IMapper mapper, IRepository<Role> rolesRepository, IUserRepository usersRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
        _usersRepository = usersRepository;
    }

    public async Task Create(CreateRoleDTO roleDto)
    {
        var role = _mapper.Map<CreateRoleDTO, Role>(roleDto);

        await _rolesRepository.InsertOneAsync(role);
    }

    public async Task Delete(string id)
    {
        await _rolesRepository.DeleteByIdAsync(id);
    }

    public List<RoleDTO> GetAll()
    {
        var roles = _rolesRepository.AsQueryable().ToList();
        
        var rolesDtos = _mapper.Map<List<Role>, List<RoleDTO>>(roles);

        return rolesDtos;
    }

    public async Task AssignRoleToUser(AssignRoleDTO assignRoleDto)
    {
        var role = await _rolesRepository.FindOneAsync(r => r.Name == assignRoleDto.Role);
        if (role == null)
        {
            throw new NotFoundException($"The specified role {assignRoleDto.Role} does not exist");
        }
        await _usersRepository.AssignRoleAsync(assignRoleDto.UserId, assignRoleDto.Role);
    }
}