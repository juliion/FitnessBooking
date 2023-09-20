using AutoMapper;
using FitnessBooking.BLL.DTOs.Instructors.Requests;
using FitnessBooking.BLL.DTOs.Instructors.Responses;
using FitnessBooking.BLL.Interfaces;
using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;

namespace FitnessBooking.BLL.Services;

public class InstructorService : IInstructorService
{
    private readonly IRepository<Instructor> _instructorsRepository;
    private readonly IMapper _mapper;

    public InstructorService(IRepository<Instructor> instructorsRepository, IMapper mapper)
    {
        _instructorsRepository = instructorsRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateInstructorDTO instructorDto)
    {
        var instructor = _mapper.Map<CreateInstructorDTO, Instructor>(instructorDto);

        var id = await _instructorsRepository.InsertOneAsync(instructor);
        return id;
    }

    public async Task Update(string id, UpdateInstructorDTO instructorDto)
    {
        var instructor = _mapper.Map<UpdateInstructorDTO, Instructor>(instructorDto);
        instructor.Id = id;

        await _instructorsRepository.ReplaceOneAsync(instructor);
    }

    public async Task Delete(string id)
    {
        await _instructorsRepository.DeleteByIdAsync(id);
    }

    public List<InstructorDTO> GetAll()
    {
        var instructors = _instructorsRepository.AsQueryable().ToList();
        
        var instructorDtos = _mapper.Map<List<Instructor>, List<InstructorDTO>>(instructors);
        return instructorDtos;
    }

    public async Task<InstructorDTO> Get(string id)
    {
        var instructor = await _instructorsRepository.FindByIdAsync(id);
        
        var instructorDto = _mapper.Map<Instructor, InstructorDTO>(instructor);
        return instructorDto;
    }
}