using HMS.Domain.Entities;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<ApplicationUser?> GetByIdAsync(int userId);

        Task UpdateAsync(ApplicationUser user);

        Task SaveChangesAsync();
    }
}