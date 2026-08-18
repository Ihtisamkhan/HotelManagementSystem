using HMS.Application.Dtos.Room;
using HMS.Domain.Enums;

namespace HMS.Application.Interfaces
{
    public interface IRoomService
    {
        // Manager
        Task<IEnumerable<Roomdto>> GetAllAsync();

        Task<Roomdto?> GetByIdAsync(int id);

        Task CreateAsync(CreateRoomdto dto);

        Task UpdateAsync(int id, UpdateRoomdto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<Roomdto>> GetRoomsByStatusAsync(RoomStatus status);

        // Customer / Public Website
        Task<IEnumerable<Roomdto>> GetAvailableRoomsAsync();

        Task<IEnumerable<Roomdto>> GetRoomsByTypeAsync(int roomTypeId);
    }
}