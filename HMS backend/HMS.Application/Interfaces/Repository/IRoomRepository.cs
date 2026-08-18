using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        // Manager
        Task<IEnumerable<Room>> GetAllAsync();

        Task<Room?> GetByIdAsync(int id);

        Task<Room?> GetByRoomNumberAsync(string roomNumber);

        Task CreateAsync(Room room);

        Task UpdateAsync(Room room);

        Task DeleteAsync(Room room);

        // owner
        Task<IEnumerable<Room>> GetRoomsByStatusAsync(RoomStatus status);

        // Customer
        Task<IEnumerable<Room>> GetAvailableRoomsAsync();

        Task<IEnumerable<Room>> GetRoomsByTypeAsync(int roomTypeId);

        Task SaveChangesAsync();
    }
}
