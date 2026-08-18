using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;
using HMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public async Task<Booking?> GetByIdAsync(int bookingId)
        {
            return await _context.Bookings
                .Include(x => x.Room)
                .Include(x => x.Customer)
                .Include(x => x.AcceptedByUser)
                .FirstOrDefaultAsync(x => x.BookingId == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(x => x.Room)
                .Include(x => x.Customer)
                .OrderByDescending(x => x.BookingDate)
                .ToListAsync();
        }

        public async Task<bool> HasOverlappingBookingAsync(
    int roomId,
    DateTime checkInDate,
    DateTime checkOutDate)
        {
            return await _context.Bookings.AnyAsync(x =>
                x.RoomId == roomId &&
                x.Status != BookingStatus.Rejected &&
                checkInDate < x.CheckOutDate &&
                checkOutDate > x.CheckInDate);
        }
        public async Task<IEnumerable<Booking>> GetMyBookingsAsync(int customerUserId)
        {
            return await _context.Bookings
                .Include(x => x.Room)
                .Where(x => x.CustomerUserId == customerUserId)
                .OrderByDescending(x => x.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetPendingBookingsAsync()
        {
            return await _context.Bookings
                .Include(x => x.Room)
                .Include(x => x.Customer)
                .Where(x => x.Status == BookingStatus.Pending)
                .OrderBy(x => x.BookingDate)
                .ToListAsync();
        }

        public Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(BookingStatus? status)
        {
            var query = _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Room)
                .AsQueryable();

            if (status != null)
                query = query.Where(x => x.Status == status);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetAcceptedBookingsAsync()
        {
            return await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Room)
                .Where(x =>
                    x.Status == BookingStatus.Accepted ||
                    x.Status == BookingStatus.CheckedIn ||
                    x.Status == BookingStatus.CheckedOut)
                .OrderByDescending(x => x.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetRejectedBookingsAsync()
        {
            return await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Room)
                .Where(x => x.Status == BookingStatus.Rejected)
                .OrderByDescending(x => x.BookingDate)
                .ToListAsync();
        }


    }
}
