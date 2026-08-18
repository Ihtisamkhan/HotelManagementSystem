using HMS.Application.Dtos.Booking;
using HMS.Domain.Enums;

namespace HMS.Application.Interfaces
{
    public interface IBookingService
    {
        // Customer
        Task CreateBookingAsync(int customerUserId, CreateBookingdto dto);

        Task<IEnumerable<Bookingdto>> GetMyBookingsAsync(int customerUserId);

        Task<Bookingdto?> GetBookingByIdAsync(int bookingId);

        // Receptionist
        Task<IEnumerable<Bookingdto>> GetPendingBookingsAsync();

        Task AcceptBookingAsync(int bookingId, int receptionistUserId);

        Task RejectBookingAsync(int bookingId, int receptionistUserId);

        Task<IEnumerable<Bookingdto>> GetAllBookingsAsync();

        // Customer Check-In / Check-Out
        Task CustomerCheckInAsync(int bookingId, int customerUserId);

        Task CustomerCheckOutAsync(int bookingId, int customerUserId);

        // Owner
        Task<IEnumerable<Bookingdto>> GetBookingsByStatusAsync(BookingStatus? status);

        Task<IEnumerable<Bookingdto>> GetAcceptedBookingsAsync();

        Task<IEnumerable<Bookingdto>> GetRejectedBookingsAsync();
    }
}