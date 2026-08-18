namespace HMS.Application.Dtos.Dashboard
{
    public class ReceptionistDashboardDto
    {
        public int PendingBookings { get; set; }

        public int AcceptedBookings { get; set; }

        public int RejectedBookings { get; set; }

        public int TodayCheckIns { get; set; }

        public int TodayCheckOuts { get; set; }
    }
}
