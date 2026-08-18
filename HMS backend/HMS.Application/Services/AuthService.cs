using AutoMapper;
using HMS.Application.Dtos.Auth;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(
            IAuthRepository authRepository,
            IJwtService jwtService,
            IMapper mapper)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task RegisterOwnerAsync(RegisterOwnerdto dto)
        {
            // Check if Owner already exists
            if (await _authRepository.OwnerExistsAsync())
            {
                throw new Exception("Owner is already registered.");
            }

            // Check password confirmation
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }

            // Map DTO to ApplicationUser
            var user = _mapper.Map<ApplicationUser>(dto);

            // Identity uses UserName property
            user.UserName = dto.Username;

            // Create user
            var result = await _authRepository.CreateUserAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    result.Errors.Select(x => x.Description)));
            }

            // Assign Owner role
            await _authRepository.AddToRoleAsync(user, Roles.Owner);
        }

        public async Task RegisterCustomerAsync(RegisterCustomerdto dto)
        {
            // Check password confirmation
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }

            // Check username already exists
            var existingUser = await _authRepository.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Map DTO to ApplicationUser
            var user = _mapper.Map<ApplicationUser>(dto);

            user.UserName = dto.Username;

            // Create Identity user
            var result = await _authRepository.CreateUserAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    result.Errors.Select(x => x.Description)));
            }

            // Assign Customer role
            var roleResult = await _authRepository.AddToRoleAsync(user, Roles.Customer);

            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    roleResult.Errors.Select(x => x.Description)));
            }
        }

        public async Task<LoginResponsedto> LoginAsync(Logindto dto)
        {
            // Find user by username
            var user = await _authRepository.GetByUsernameAsync(dto.Username);

            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            // Verify password
            var validPassword = await _authRepository.CheckPasswordAsync(user, dto.Password);

            if (!validPassword)
            {
                throw new Exception("Invalid username or password.");
            }

            // Get user roles
            var roles = await _authRepository.GetRolesAsync(user);

            // Generate JWT token
            var token = _jwtService.GenerateToken(user, roles);

            // Return response
            return new LoginResponsedto
            {
                Token = token,
                Username = user.UserName ?? string.Empty,
                Role = roles.FirstOrDefault() ?? string.Empty
            };
        }

        public async Task CreateEmployeeAsync(CreateEmployeedto dto)
        {
            // Check if username already exists
            var existingUser = await _authRepository.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Map DTO to ApplicationUser
            var user = _mapper.Map<ApplicationUser>(dto);

            // Identity uses UserName
            user.UserName = dto.Username;

            // Create Identity user
            var result = await _authRepository.CreateUserAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    result.Errors.Select(x => x.Description)));
            }

            // Assign role
            var roleResult = await _authRepository.AddToRoleAsync(user, dto.Role);

            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    roleResult.Errors.Select(x => x.Description)));
            }
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeedto dto)
        {
            // Find employee
            var user = await _authRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("Employee not found.");
            }

            // Update properties
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            // Save changes
            var result = await _authRepository.UpdateUserAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    result.Errors.Select(x => x.Description)));
            }
        }

        public async Task ChangePasswordAsync(int userId, ChangePassworddto dto)
        {
            // Find user
            var user = await _authRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Check new password confirmation
            if (dto.NewPassword != dto.ConfirmPassword)
            {
                throw new Exception("New Password and Confirm Password do not match.");
            }

            // Change password
            var result = await _authRepository.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ",
                    result.Errors.Select(x => x.Description)));
            }
        }

        public async Task<IEnumerable<Employeedto>> GetEmployeesByRoleAsync(string role)
        {
            var users = await _authRepository.GetUsersInRoleAsync(role);

            return users.Select(x => new Employeedto
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName!,
                Role = role
            });
        }

        public async Task<IEnumerable<UserListdto>> GetUsersByRoleAsync(string role)
        {
            var users = await _authRepository.GetUsersByRoleAsync(role);

            return users.Select(x => new UserListdto
            {
                Id = x.Id,
                FullName = x.FullName,
                Username = x.UserName!,
                Email = x.Email!,
                PhoneNumber = x.PhoneNumber!,
                IsActive = x.IsActive
            });
        }
    }
}
