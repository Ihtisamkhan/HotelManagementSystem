using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Persistence.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly AppDbContext _context;

        public RoomTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> GetByIdAsync(int id)
        {
            return await _context.RoomTypes
                .FirstOrDefaultAsync(x => x.RoomTypeId == id);
        }

        public async Task<RoomType?> GetByNameAsync(string name)
        {
            return await _context.RoomTypes
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task CreateAsync(RoomType roomType)
        {
            await _context.RoomTypes.AddAsync(roomType);
        }

        public Task UpdateAsync(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(RoomType roomType)
        {
            _context.RoomTypes.Remove(roomType);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
