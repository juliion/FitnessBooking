
using AutoMapper;
using FitnessBooking.BLL.Common.Exceptions;
using FitnessBooking.BLL.DTOs.FitnessClasses.Requests;
using FitnessBooking.BLL.DTOs.FitnessClasses.Responses;
using FitnessBooking.BLL.Interfaces;
using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;

namespace FitnessBooking.BLL.Services;

public class FitnessClassService : IFitnessClassService
{
    private readonly IRepository<FitnessClass> _classesRepository;
    private readonly IMapper _mapper;

    public FitnessClassService(IRepository<FitnessClass> classesRepository, IMapper mapper)
    {
        _classesRepository = classesRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateClassDTO classDto)
    {
        var fitnessClass = _mapper.Map<CreateClassDTO, FitnessClass>(classDto);
        
        var id = await _classesRepository.InsertOneAsync(fitnessClass);
        return id;
    }

    public async Task Update(string id, UpdateClassDTO classDto)
    {
        var fitnessClass = _mapper.Map<UpdateClassDTO, FitnessClass>(classDto);
        fitnessClass.Id = id;
        
        await _classesRepository.ReplaceOneAsync(fitnessClass);
    }

    public async Task Delete(string id)
    {
        await _classesRepository.DeleteByIdAsync(id);
    }

    public List<FitnessClassDTO> GetAll()
    {
        var classes = _classesRepository.AsQueryable().ToList();
        
        var classDtos = _mapper.Map<List<FitnessClass>, List<FitnessClassDTO>>(classes);
        
        return classDtos;
    }

    public async Task<FitnessClassDTO> Get(string id)
    {
        var fitnessClass = await _classesRepository.FindByIdAsync(id);

        if (fitnessClass == null)
        {
            throw new NotFoundException("Class not found");
        }
        
        var classDto = _mapper.Map<FitnessClass, FitnessClassDTO>(fitnessClass);

        return classDto;
    }
}