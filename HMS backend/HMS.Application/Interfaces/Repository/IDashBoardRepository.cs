using HMS.Application.Dtos.Dashboard;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        Task<OwnerDashboardDto> GetOwnerDashboardAsync();

        Task<ManagerDashboardDto> GetManagerDashboardAsync();

        Task<ReceptionistDashboardDto> GetReceptionistDashboardAsync();

        Task<int> GetTotalRoomsAsync();

        Task<int> GetAvailableRoomsAsync();

        Task<int> GetOccupiedRoomsAsync();

        Task<int> GetMaintenanceRoomsAsync();
    }
}
