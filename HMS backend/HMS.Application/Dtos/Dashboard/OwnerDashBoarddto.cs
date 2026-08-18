namespace HMS.Application.Dtos.Dashboard
{
    public class OwnerDashboardDto
    {
        // Rooms
        public int TotalRooms { get; set; }

        public int AvailableRooms { get; set; }

        public int OccupiedRooms { get; set; }

        public int MaintenanceRooms { get; set; }

        // Users
        public int TotalCustomers { get; set; }

        public int TotalManagers { get; set; }

        public int TotalReceptionists { get; set; }

        // Bookings
        public int TotalBookings { get; set; }

        public int PendingBookings { get; set; }

        public int AcceptedBookings { get; set; }

        public int RejectedBookings { get; set; }
    }
}
