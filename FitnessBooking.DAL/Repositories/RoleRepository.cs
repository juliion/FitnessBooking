using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class RoleRepository : BaseRepository<Role>
{
    public RoleRepository(IOptions<DbSettings> settings) : base(settings)
    {}
    
    
}