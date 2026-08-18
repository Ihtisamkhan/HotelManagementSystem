using HMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public decimal PricePerNight { get; set; }

        public int RoomTypeId { get; set; }

        public string RoomSize { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public string? Floor { get; set; }

        public RoomStatus Status { get; set; }

        public string? MaintenanceReason { get; set; }



        public string? Description { get; set; }

        // Navigation Properties
        public RoomType RoomType { get; set; } = null!;
    }
}
