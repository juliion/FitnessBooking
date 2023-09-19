using FitnessBooking.BLL.DTOs.FitnessClasses.Requests;
using FitnessBooking.BLL.DTOs.FitnessClasses.Responses;

namespace FitnessBooking.BLL.Interfaces;

public interface IFitnessClassService
{
    public Task<string> Create(CreateClassDTO classDto);
    public Task Update(string id, UpdateClassDTO classDto);
    public Task Delete(string id);
    public List<FitnessClassDTO> GetAll();
    public Task<FitnessClassDTO> Get(string id);
}