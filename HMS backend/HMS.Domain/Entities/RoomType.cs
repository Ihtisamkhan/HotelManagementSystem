using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Entities
{
    public  class RoomType
    {
        public int RoomTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation Property
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
