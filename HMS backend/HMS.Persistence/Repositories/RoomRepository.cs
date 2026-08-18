using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;
using HMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        // Manager
        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.RoomId == id);
        }

        public async Task<Room?> GetByRoomNumberAsync(string roomNumber)
        {
            return await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        }

        // Customer
        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.Status == RoomStatus.Available)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsByTypeAsync(int roomTypeId)
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.RoomTypeId == roomTypeId &&
                            r.Status == RoomStatus.Available)
                .ToListAsync();
        }

        // Manager
        public async Task CreateAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Room room)
        {
            _context.Rooms.Remove(room);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // owner
        public async Task<IEnumerable<Room>> GetRoomsByStatusAsync(RoomStatus status)
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                 .Include(r => r.Bookings)
            .ThenInclude(b => b.Customer)
                .Where(r => r.Status == status)
                .ToListAsync();
        }
    }
}
