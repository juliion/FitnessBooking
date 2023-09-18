using FitnessBooking.DAL.Entities;
using FitnessBooking.DAL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FitnessBooking.DAL.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IOptions<DbSettings> settings) : base(settings)
    {}
    
    public async Task AssignRoleAsync(string userId, string role)
    {
        var filter = Builders<User>.Filter.Eq(s => s.Id, userId);
        var update = Builders<User>.Update
            .Push(s => s.Roles, role);
        
        await _context.GetCollection<User>()
            .UpdateOneAsync(filter, update);
    }
}