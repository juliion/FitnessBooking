using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class ReviewRepository : BaseRepository<Review>
{
    public ReviewRepository(IOptions<DbSettings> settings) : base(settings)
    {}
}