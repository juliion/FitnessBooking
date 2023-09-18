using FitnessBooking.BLL.DTOs.Roles.Requests;
using FitnessBooking.BLL.DTOs.Roles.Responses;

namespace FitnessBooking.BLL.Interfaces;

public interface IRoleService
{
    public Task<string> Create(CreateRoleDTO roleDto);
    public Task Delete(string id);
    public List<RoleDTO> GetAll();
    public Task AssignRoleToUser(AssignRoleDTO assignRoleDto);
}