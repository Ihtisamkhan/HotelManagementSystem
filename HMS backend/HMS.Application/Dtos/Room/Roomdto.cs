using HMS.Domain.Enums;

namespace HMS.Application.Dtos.Room
{
    public class Roomdto
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public string RoomSize { get; set; } = string.Empty;

        public string RoomTypeName { get; set; } = string.Empty;

        public string? Floor { get; set; }

        public decimal PricePerNight { get; set; }

        public RoomStatus Status { get; set; }

        public string? CustomerName { get; set; }



        public string? Description { get; set; }
    }
}