using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.StaffTask
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int StaffId { get; set; }

        public int? RoomId { get; set; }

        public bool IsMaintenanceTask { get; set; }

        public string? MaintenanceReason { get; set; }
    }
}
