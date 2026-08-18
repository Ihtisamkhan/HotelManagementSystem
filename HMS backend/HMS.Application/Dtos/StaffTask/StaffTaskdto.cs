using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.StaffTask
{
    public class StaffTaskDto
    {
        public int StaffTaskId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string StaffName { get; set; } = string.Empty;

        public string? RoomNumber { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }

        public DateTime? CompletedDate { get; set; }
    }
}