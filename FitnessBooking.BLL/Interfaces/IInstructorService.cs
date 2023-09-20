using FitnessBooking.BLL.DTOs.Instructors.Requests;
using FitnessBooking.BLL.DTOs.Instructors.Responses;

namespace FitnessBooking.BLL.Interfaces;

public interface IInstructorService
{
    public Task<string> Create(CreateInstructorDTO instructorDto);
    public Task Update(string id, UpdateInstructorDTO instructorDto);
    public Task Delete(string id);
    public List<InstructorDTO> GetAll();
    public Task<InstructorDTO> Get(string id);
}