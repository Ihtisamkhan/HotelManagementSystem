using HMS.Domain.Entities;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAllAsync();

        Task<RoomType?> GetByIdAsync(int id);

        Task<RoomType?> GetByNameAsync(string name);

        Task CreateAsync(RoomType roomType);

        Task UpdateAsync(RoomType roomType);

        Task DeleteAsync(RoomType roomType);

        Task SaveChangesAsync();
    }
}
