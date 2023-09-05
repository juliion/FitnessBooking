using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class InstructorRepository : BaseRepository<Instructor>
{
    public InstructorRepository(IOptions<DbSettings> settings) : base(settings)
    {}
}