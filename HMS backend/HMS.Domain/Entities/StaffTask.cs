using System;
using System.Collections.Generic;
using System.Text;
using HMS.Domain.Enums;

namespace HMS.Domain.Entities
{
    public class StaffTask
    {
        public int StaffTaskId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Staff who will perform the task
        public int StaffId { get; set; }

        public ApplicationUser Staff { get; set; } = null!;

        // Manager who assigned the task
        public int AssignedByUserId { get; set; }

        public ApplicationUser AssignedByUser { get; set; } = null!;

        // Optional room
        public int? RoomId { get; set; }

        public Room? Room { get; set; }

        public StaffTaskStatus Status { get; set; } = StaffTaskStatus.Pending;

        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedDate { get; set; }
    }
}