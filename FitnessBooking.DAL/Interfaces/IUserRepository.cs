using FitnessBooking.DAL.Entities;

namespace FitnessBooking.DAL.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public Task AssignRoleAsync(string userId, string role);
}