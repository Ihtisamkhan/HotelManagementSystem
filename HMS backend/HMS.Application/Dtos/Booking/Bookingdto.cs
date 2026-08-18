using HMS.Domain.Enums;
using System;

namespace HMS.Application.Dtos.Booking
{
    public class Bookingdto
    {
        public int BookingId { get; set; }

        public string? BookingReference { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string RoomNumber { get; set; } = string.Empty;

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        // NEW
        public DateTime? ActualCheckInTime { get; set; }

        // NEW
        public DateTime? ActualCheckOutTime { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime BookingDate { get; set; }
    }
}