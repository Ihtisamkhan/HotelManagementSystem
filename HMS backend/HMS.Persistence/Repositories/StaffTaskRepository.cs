using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;
using HMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Persistence.Repositories
{
    public class StaffTaskRepository : IStaffTaskRepository
    {
        private readonly AppDbContext _context;

        public StaffTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StaffTask task)
        {
            await _context.StaffTasks.AddAsync(task);
        }

        public async Task UpdateAsync(StaffTask task)
        {
            _context.StaffTasks.Update(task);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(StaffTask task)
        {
            _context.StaffTasks.Remove(task);

            await Task.CompletedTask;
        }

        public async Task<StaffTask?> GetByIdAsync(int id)
        {
            return await _context.StaffTasks
                .Include(x => x.Staff)
                .Include(x => x.Room)
                .Include(x => x.AssignedByUser)
                .FirstOrDefaultAsync(x => x.StaffTaskId == id);
        }

        public async Task<IEnumerable<StaffTask>> GetAllAsync()
        {
            return await _context.StaffTasks
                .Include(x => x.Staff)
                .Include(x => x.Room)
                .Include(x => x.AssignedByUser)
                .OrderByDescending(x => x.AssignedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StaffTask>> GetTasksByStaffIdAsync(int staffId)
        {
            return await _context.StaffTasks
                .Include(x => x.Room)
                .Where(x =>
                    x.StaffId == staffId &&
                    x.Status != StaffTaskStatus.Completed)
                .OrderByDescending(x => x.AssignedDate)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffTask>> GetCompletedTasksAsync(int staffId)
        {
            return await _context.StaffTasks
                .Include(x => x.Room)
                .Where(x =>
                    x.StaffId == staffId &&
                    x.Status == StaffTaskStatus.Completed)
                .OrderByDescending(x => x.CompletedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StaffTask>> GetTaskStatusAsync()
        {
            return await _context.StaffTasks
                .Include(x => x.Staff)
                .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                .OrderByDescending(x => x.AssignedDate)
                .ToListAsync();
        }
    }
}
