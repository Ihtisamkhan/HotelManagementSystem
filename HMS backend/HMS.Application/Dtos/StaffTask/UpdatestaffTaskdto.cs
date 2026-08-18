using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.StaffTask
{
    public class UpdateTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int StaffId { get; set; }

        public int? RoomId { get; set; }
    }
}