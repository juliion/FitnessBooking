using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class FitnessClassRepository : BaseRepository<FitnessClass>
{
    public FitnessClassRepository(IOptions<DbSettings> settings) : base(settings)
    {}
}