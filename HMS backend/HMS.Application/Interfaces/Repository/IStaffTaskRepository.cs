using System;
using System.Collections.Generic;
using System.Text;

using HMS.Domain.Entities;

namespace HMS.Application.Interfaces.Repositories
{
    public interface IStaffTaskRepository
    {
        Task CreateAsync(StaffTask task);

        Task UpdateAsync(StaffTask task);

        Task DeleteAsync(StaffTask task);

        Task<StaffTask?> GetByIdAsync(int id);

        Task<IEnumerable<StaffTask>> GetAllAsync();

        Task<IEnumerable<StaffTask>> GetCompletedTasksAsync(int staffId);

        Task<IEnumerable<StaffTask>> GetTasksByStaffIdAsync(int staffId);

        Task<IEnumerable<StaffTask>> GetTaskStatusAsync();

        Task SaveChangesAsync();
    }
}
