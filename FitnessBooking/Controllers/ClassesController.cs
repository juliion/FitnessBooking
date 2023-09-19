using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.FitnessClasses.Requests;
using FitnessBooking.BLL.DTOs.FitnessClasses.Responses;
using FitnessBooking.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class ClassesController : ControllerBase
{
    private readonly IFitnessClassService _classService;

    public ClassesController(IFitnessClassService classService)
    {
        _classService = classService;
    }

    public IActionResult GetAll()
    {
        var classes =  _classService.GetAll();
        
        return Ok(classes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        FitnessClassDTO fitnessClass;
        try
        {
            fitnessClass = await _classService.Get(id);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        return Ok(fitnessClass);
    }
    
    [Authorize(Roles="admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateClassDTO classDto)
    {
        var id = await _classService.Create(classDto);

        return Ok(id);
    }
    
    [Authorize(Roles="admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateClassDTO classDto)
    {
        await _classService.Update(id, classDto);

        return Ok();
    }
    
    [Authorize(Roles="admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _classService.Delete(id);

        return Ok();
    }
    
}