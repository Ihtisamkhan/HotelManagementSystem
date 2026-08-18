using System;

namespace HMS.Application.Dtos.Booking
{
    public class CreateBookingdto
    {
        

        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
        
    }
}
