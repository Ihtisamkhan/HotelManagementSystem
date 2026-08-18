using HMS.Application.Dtos.RoomType;

namespace HMS.Application.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypedto>> GetAllAsync();

        Task<RoomTypedto?> GetByIdAsync(int id);

        Task CreateAsync(CreateRoomTypedto dto);

        Task UpdateAsync(int id, UpdateRoomTypedto dto);

        Task DeleteAsync(int id);
    }
}
