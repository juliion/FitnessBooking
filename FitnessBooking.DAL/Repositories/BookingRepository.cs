using FitnessBooking.DAL.Entities;
using Microsoft.Extensions.Options;

namespace FitnessBooking.DAL.Repositories;

public class BookingRepository : BaseRepository<Booking>
{
    public BookingRepository(IOptions<DbSettings> settings) : base(settings)
    {}
}