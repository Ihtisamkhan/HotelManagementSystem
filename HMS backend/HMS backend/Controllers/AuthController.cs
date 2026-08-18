using HMS.Application.Dtos.Auth;
using HMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Register Owner (Only Once)
        [HttpPost("register-owner")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterOwner(RegisterOwnerdto dto)
        {
            await _authService.RegisterOwnerAsync(dto);
            return Ok(new { message = "Owner registered successfully." });
        }

        // Register Customer
        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerdto dto)
        {
            await _authService.RegisterCustomerAsync(dto);

            return Ok(new
            {
                message = "Customer registered successfully."
            });
        }

        // Login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Logindto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }

        // Create Employee
        [HttpPost("create-employee")]
        [Authorize(Roles = "Owner,Manager")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeedto dto)
        {
            await _authService.CreateEmployeeAsync(dto);
            return Ok(new { message = "Employee created successfully." });
        }

        [HttpGet("staff")]
        [Authorize(Roles = "Owner,Manager")]
        public async Task<IActionResult> GetStaff()
        {
            var staff = await _authService.GetEmployeesByRoleAsync("Staff");

            return Ok(staff);
        }

        // Update Employee
        [HttpPut("update-employee/{id}")]
        [Authorize(Roles = "Owner,Manager")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeedto dto)
        {
            await _authService.UpdateEmployeeAsync(id, dto);
            return Ok(new { message = "Employee updated successfully." });
        }

        // Change Password
        [HttpPut("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePassworddto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _authService.ChangePasswordAsync(userId, dto);

            return Ok(new { message = "Password changed successfully." });
        }

        [HttpGet("users/{role}")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            var users = await _authService.GetUsersByRoleAsync(role);

            return Ok(users);
        }
    }
}
