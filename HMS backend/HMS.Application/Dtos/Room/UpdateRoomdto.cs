using HMS.Domain.Enums;

namespace HMS.Application.Dtos.Room
{
    public class UpdateRoomdto
    {
        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public string? Floor { get; set; }

        public decimal PricePerNight { get; set; }

        public RoomStatus Status { get; set; }

        

        public string? Description { get; set; }
    }
}
