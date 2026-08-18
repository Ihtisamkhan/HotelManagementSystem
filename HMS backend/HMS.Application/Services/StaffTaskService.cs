using AutoMapper;
using HMS.Application.Dtos.StaffTask;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Services
{
    public class StaffTaskService : IStaffTaskService
    {
        private readonly IStaffTaskRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public StaffTaskService(
            IStaffTaskRepository repository,
            IRoomRepository roomRepository,
            IMapper mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task CreateTaskAsync(int managerUserId, CreateTaskDto dto)
        {
            var task = _mapper.Map<StaffTask>(dto);

            task.AssignedByUserId = managerUserId;
            task.AssignedDate = DateTime.UtcNow;
            task.Status = StaffTaskStatus.Pending;

            // If this is a maintenance task
            if (dto.IsMaintenanceTask && dto.RoomId.HasValue)
            {
                var room = await _roomRepository.GetByIdAsync(dto.RoomId.Value);

                if (room == null)
                    throw new Exception("Room not found.");

                room.Status = RoomStatus.Maintenance;
                room.MaintenanceReason = dto.MaintenanceReason;

                await _roomRepository.UpdateAsync(room);
            }

            await _repository.CreateAsync(task);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffTaskDto>> GetAllTasksAsync()
        {
            var tasks = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<StaffTaskDto>>(tasks);
        }

        public async Task<IEnumerable<StaffTaskDto>> GetMyTasksAsync(int staffId)
        {
            var tasks = await _repository.GetTasksByStaffIdAsync(staffId);

            return _mapper.Map<IEnumerable<StaffTaskDto>>(tasks);
        }

        public async Task UpdateTaskAsync(int id, UpdateTaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found.");

            _mapper.Map(dto, task);

            await _repository.UpdateAsync(task);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found.");

            await _repository.DeleteAsync(task);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateTaskStatusAsync(int taskId, int staffId)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
                throw new Exception("Task not found.");

            if (task.StaffId != staffId)
                throw new Exception("You are not allowed to update this task.");

            if (task.Status == StaffTaskStatus.Completed)
                throw new Exception("Task is already completed.");

            task.Status = StaffTaskStatus.Completed;
            task.CompletedDate = DateTime.UtcNow;

            // If it was a maintenance task,
            // make the room available again.
            if (task.RoomId.HasValue)
            {
                var room = await _roomRepository.GetByIdAsync(task.RoomId.Value);

                if (room != null &&
                    room.Status == RoomStatus.Maintenance)
                {
                    room.Status = RoomStatus.Available;
                    room.MaintenanceReason = null;

                    await _roomRepository.UpdateAsync(room);
                }
            }

            await _repository.UpdateAsync(task);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffTaskDto>> GetCompletedTasksAsync(int staffId)
        {
            var tasks = await _repository.GetCompletedTasksAsync(staffId);

            return _mapper.Map<IEnumerable<StaffTaskDto>>(tasks);
        }

        public async Task<IEnumerable<TaskStatusDto>> GetTaskStatusAsync()
        {
            var tasks = await _repository.GetTaskStatusAsync();

            return tasks.Select(x => new TaskStatusDto
            {
                TaskId = x.StaffTaskId,
                TaskTitle = x.Title,
                StaffName = x.Staff.FullName,
                RoomNumber = x.Room != null ? x.Room.RoomNumber : "",
                RoomType = x.Room != null ? x.Room.RoomType.Name : "",
                AssignedDate = x.AssignedDate,
                Status = x.Status.ToString()
            });
        }
    }
}