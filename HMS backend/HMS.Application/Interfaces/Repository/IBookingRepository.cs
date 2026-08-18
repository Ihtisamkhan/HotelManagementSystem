using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        // Customer
        Task CreateAsync(Booking booking);

        Task<Booking?> GetByIdAsync(int bookingId);

        Task<bool> HasOverlappingBookingAsync(
    int roomId,
    DateTime checkInDate,
    DateTime checkOutDate);

        Task<IEnumerable<Booking>> GetMyBookingsAsync(int customerUserId);

        // Receptionist
        Task<IEnumerable<Booking>> GetPendingBookingsAsync();

        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        // Common
        Task UpdateAsync(Booking booking);

        Task SaveChangesAsync();



        Task<IEnumerable<Booking>> GetBookingsByStatusAsync(BookingStatus? status);

        Task<IEnumerable<Booking>> GetAcceptedBookingsAsync();

        Task<IEnumerable<Booking>> GetRejectedBookingsAsync();


        




    }
}
