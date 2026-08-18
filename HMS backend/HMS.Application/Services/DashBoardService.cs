using HMS.Application.Dtos.Dashboard;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;

namespace HMS.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<OwnerDashboardDto> GetOwnerDashboardAsync()
        {
            return await _dashboardRepository.GetOwnerDashboardAsync();
        }

        public async Task<ManagerDashboardDto> GetManagerDashboardAsync()
        {
            return await _dashboardRepository.GetManagerDashboardAsync();
        }

        public async Task<ReceptionistDashboardDto> GetReceptionistDashboardAsync()
        {
            return await _dashboardRepository.GetReceptionistDashboardAsync();
        }

        public async Task<RoomStatisticsDto> GetRoomStatisticsAsync()
        {
            return new RoomStatisticsDto
            {
                TotalRooms = await _dashboardRepository.GetTotalRoomsAsync(),

                AvailableRooms = await _dashboardRepository.GetAvailableRoomsAsync(),

                OccupiedRooms = await _dashboardRepository.GetOccupiedRoomsAsync(),

                MaintenanceRooms = await _dashboardRepository.GetMaintenanceRoomsAsync()
            };
        }
    }
}
