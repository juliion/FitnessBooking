using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(IOptions<DbSettings> settings) : base(settings)
    {}
}