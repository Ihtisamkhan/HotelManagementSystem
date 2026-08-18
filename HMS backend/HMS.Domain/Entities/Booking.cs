using HMS.Domain.Enums;

namespace HMS.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        // Customer
        public int CustomerUserId { get; set; }

        public ApplicationUser Customer { get; set; } = null!;

        // Room
        public int RoomId { get; set; }

        public Room Room { get; set; } = null!;

        // Booking Dates
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        // Booking Status
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public DateTime? BookingStatusUpdateDate { get; set; }

        // Receptionist who accepted the booking
        public int? AcceptedByUserId { get; set; }

        public ApplicationUser? AcceptedByUser { get; set; }

        // Customer Actual Check-In Time
        public DateTime? ActualCheckInTime { get; set; }

        // Customer Actual Check-Out Time
        public DateTime? ActualCheckOutTime { get; set; }

        // Booking Created Time
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    }
}