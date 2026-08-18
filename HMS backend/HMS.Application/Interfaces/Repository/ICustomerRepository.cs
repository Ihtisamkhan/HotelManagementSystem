using HMS.Domain.Entities;

namespace HMS.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<ApplicationUser?> GetByIdAsync(int id);

        Task UpdateAsync(ApplicationUser customer);

        Task SaveChangesAsync();
    }
}
