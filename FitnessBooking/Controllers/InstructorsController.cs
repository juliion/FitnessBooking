using System.Security.Claims;
using FitnessBooking.BLL.DTOs.Instructors.Requests;
using FitnessBooking.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class InstructorsController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorsController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var instructor = await _instructorService.Get(id);
        
        return Ok(instructor);
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var instructors = _instructorService.GetAll();
        
        return Ok(instructors);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateInstructorDTO instructorDto)
    {
        await _instructorService.Update(id, instructorDto);
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _instructorService.Delete(id);
        
        return Ok();
    }
}