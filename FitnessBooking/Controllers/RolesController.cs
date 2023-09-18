using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.Roles.Requests;
using FitnessBooking.BLL.Interfaces;
using FitnessBooking.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[Authorize(Roles="admin")]
[ApiController]
[Route("api/[controller]/[action]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleDTO roleDto)
    {
        await _roleService.Create(roleDto);
        
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Assign(AssignRoleDTO roleDto)
    {
        try
        {
            await _roleService.AssignRoleToUser(roleDto);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }
    
    public IActionResult GetAll()
    {
        var roles = _roleService.GetAll();
        
        return Ok(roles);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _roleService.Delete(id);
        
        return Ok();
    }
}