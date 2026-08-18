using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Enums;
using HMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HMS.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> OwnerExistsAsync()
        {
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, Roles.Owner))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<ApplicationUser?> GetByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<ApplicationUser?> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(
            ApplicationUser user,
            string currentPassword,
            string newPassword)
        {
            return await _userManager.ChangePasswordAsync(
                user,
                currentPassword,
                newPassword);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string role)
        {
            return await _userManager.GetUsersInRoleAsync(role);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);

            return users;
        }
    }
}
