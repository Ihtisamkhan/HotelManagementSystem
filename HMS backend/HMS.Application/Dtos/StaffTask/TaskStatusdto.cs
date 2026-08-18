namespace HMS.Application.Dtos.StaffTask
{
    public class TaskStatusDto
    {
        public int TaskId { get; set; }

        public string TaskTitle { get; set; } = string.Empty;

        public string StaffName { get; set; } = string.Empty;

        public string RoomNumber { get; set; } = string.Empty;

        public string RoomType { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
