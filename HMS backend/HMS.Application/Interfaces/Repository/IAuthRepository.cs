using HMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> OwnerExistsAsync();

        Task<ApplicationUser?> GetByUsernameAsync(string username);

        Task<ApplicationUser?> GetByIdAsync(int id);

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);

       

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<IList<string>> GetRolesAsync(ApplicationUser user);

        Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string role);

        Task<IEnumerable<ApplicationUser>> GetUsersByRoleAsync(string role);

        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);

        Task<IdentityResult> ChangePasswordAsync(
            ApplicationUser user,
            string currentPassword,
            string newPassword);
    }
}
