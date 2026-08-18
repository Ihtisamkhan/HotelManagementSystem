using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.Dashboard
{
    public class RoomStatisticsDto
    {
        public int TotalRooms { get; set; }

        public int AvailableRooms { get; set; }

        public int OccupiedRooms { get; set; }

        public int MaintenanceRooms { get; set; }
    }
}
