using HMS.Application.Dtos.Dashboard;

namespace HMS.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<OwnerDashboardDto> GetOwnerDashboardAsync();

        Task<ManagerDashboardDto> GetManagerDashboardAsync();

        Task<ReceptionistDashboardDto> GetReceptionistDashboardAsync();

        Task<RoomStatisticsDto> GetRoomStatisticsAsync();
    }
}
