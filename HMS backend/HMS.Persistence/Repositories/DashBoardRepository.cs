using HMS.Application.Dtos.Dashboard;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;
using HMS.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Persistence.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardRepository(
            AppDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<OwnerDashboardDto> GetOwnerDashboardAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return new OwnerDashboardDto
            {
                // Rooms
                TotalRooms = await _context.Rooms.CountAsync(),
                AvailableRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Available),
                OccupiedRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Occupied),
                MaintenanceRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Maintenance),

                // Users
                TotalCustomers = users.Count(u => _userManager.IsInRoleAsync(u, Roles.Customer).Result),
                TotalManagers = users.Count(u => _userManager.IsInRoleAsync(u, Roles.Manager).Result),
                TotalReceptionists = users.Count(u => _userManager.IsInRoleAsync(u, Roles.Receptionist).Result),

                // Bookings
                TotalBookings = await _context.Bookings.CountAsync(),
                PendingBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Pending),
                AcceptedBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Accepted),
                RejectedBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Rejected)
            };
        }

        public async Task<ManagerDashboardDto> GetManagerDashboardAsync()
        {
            return new ManagerDashboardDto
            {
                TotalRooms = await _context.Rooms.CountAsync(),
                AvailableRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Available),
                OccupiedRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Occupied),
                MaintenanceRooms = await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Maintenance)
            };
        }

        public async Task<ReceptionistDashboardDto> GetReceptionistDashboardAsync()
        {
            return new ReceptionistDashboardDto
            {
                PendingBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Pending),
                AcceptedBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Accepted),
                RejectedBookings = await _context.Bookings.CountAsync(x => x.Status == BookingStatus.Rejected),

                TodayCheckIns = await _context.Bookings.CountAsync(x =>
                    x.CheckInDate.Date == DateTime.Today &&
                    x.Status == BookingStatus.Accepted),

                TodayCheckOuts = await _context.Bookings.CountAsync(x =>
                    x.CheckOutDate.Date == DateTime.Today &&
                    x.Status == BookingStatus.Accepted)
            };
        }

        public async Task<int> GetTotalRoomsAsync()
        {
            return await _context.Rooms.CountAsync();
        }

        public async Task<int> GetAvailableRoomsAsync()
        {
            return await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Available);
        }

        public async Task<int> GetOccupiedRoomsAsync()
        {
            return await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Occupied);
        }

        public async Task<int> GetMaintenanceRoomsAsync()
        {
            return await _context.Rooms.CountAsync(x => x.Status == RoomStatus.Maintenance);
        }
    }
}
