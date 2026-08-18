using System;
using System.Collections.Generic;
using System.Text;

using HMS.Application.Dtos.StaffTask;

namespace HMS.Application.Interfaces
{
    public interface IStaffTaskService
    {
        Task CreateTaskAsync(int managerUserId, CreateTaskDto dto);

        Task<IEnumerable<StaffTaskDto>> GetAllTasksAsync();

        Task<IEnumerable<StaffTaskDto>> GetMyTasksAsync(int staffId);

        Task UpdateTaskAsync(int id, UpdateTaskDto dto);

        Task DeleteTaskAsync(int id);

        Task UpdateTaskStatusAsync(int taskId, int staffId);

        Task<IEnumerable<StaffTaskDto>> GetCompletedTasksAsync(int staffId);

        Task<IEnumerable<TaskStatusDto>> GetTaskStatusAsync();
    }
}
