using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HMS.Persistence.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetByIdAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            _context.Users.Update(user);

            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
