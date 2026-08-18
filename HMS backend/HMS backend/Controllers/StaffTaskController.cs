using HMS.Application.Dtos.StaffTask;
using HMS.Application.Interfaces;
using HMS.Application.Services;
using HMS.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffTaskController : ControllerBase
    {
        private readonly IStaffTaskService _taskService;

        public StaffTaskController(IStaffTaskService taskService)
        {
            _taskService = taskService;
        }

        // ===========================
        // Manager
        // ===========================

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _taskService.CreateTaskAsync(managerId, dto);

            return Ok("Task assigned successfully.");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            return Ok(tasks);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            await _taskService.UpdateTaskAsync(id, dto);

            return Ok("Task updated.");
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return Ok("Task deleted.");
        }

        // ===========================
        // Staff
        // ===========================

        [Authorize(Roles = "Staff")]
        [HttpGet("my-tasks")]
        public async Task<IActionResult> MyTasks()
        {
            var staffId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var tasks = await _taskService.GetMyTasksAsync(staffId);

            return Ok(tasks);
        }

        [Authorize(Roles = "Staff")]
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var staffId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _taskService.UpdateTaskStatusAsync(id, staffId);

            return Ok("Task completed.");
        }

        [Authorize(Roles = "Staff")]
        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTasks()
        {
            var staffId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var tasks = await _taskService.GetCompletedTasksAsync(staffId);

            return Ok(tasks);
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpGet("task-status")]
        public async Task<IActionResult> GetTaskStatus()
        {
            var result = await _taskService.GetTaskStatusAsync();

            return Ok(result);
        }


    }
}
