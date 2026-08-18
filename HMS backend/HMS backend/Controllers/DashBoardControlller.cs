using HMS.Application.Interfaces;
using HMS.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        
        // OWNER DASHBOARD
        

        [HttpGet("owner")]
        [Authorize(Roles = Roles.Owner)]
        public async Task<IActionResult> OwnerDashboard()
        {
            var result = await _dashboardService.GetOwnerDashboardAsync();

            return Ok(result);
        }

        
        // MANAGER DASHBOARD
        

        [HttpGet("manager")]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IActionResult> ManagerDashboard()
        {
            var result = await _dashboardService.GetManagerDashboardAsync();

            return Ok(result);
        }

        
        // RECEPTIONIST DASHBOARD
        

        [HttpGet("receptionist")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> ReceptionistDashboard()
        {
            var result = await _dashboardService.GetReceptionistDashboardAsync();

            return Ok(result);
        }

        // Owner 
        [HttpGet("room-statistics")]
        [Authorize(Roles = Roles.Owner)]
        public async Task<IActionResult> GetRoomStatistics()
        {
            var result = await _dashboardService.GetRoomStatisticsAsync();

            return Ok(result);
        }
    }
}
