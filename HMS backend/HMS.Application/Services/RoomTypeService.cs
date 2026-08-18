using AutoMapper;
using HMS.Application.Dtos.RoomType;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;

namespace HMS.Application.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public RoomTypeService(
            IRoomTypeRepository roomTypeRepository,
            IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomTypedto>> GetAllAsync()
        {
            var roomTypes = await _roomTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RoomTypedto>>(roomTypes);
        }

        public async Task<RoomTypedto?> GetByIdAsync(int id)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(id);

            if (roomType == null)
                return null;

            return _mapper.Map<RoomTypedto>(roomType);
        }

        public async Task CreateAsync(CreateRoomTypedto dto)
        {
            var exists = await _roomTypeRepository.GetByNameAsync(dto.Name);

            if (exists != null)
                throw new Exception("Room Type already exists.");

            var roomType = _mapper.Map<RoomType>(dto);

            await _roomTypeRepository.CreateAsync(roomType);

            await _roomTypeRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateRoomTypedto dto)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(id);

            if (roomType == null)
                throw new Exception("Room Type not found.");

            roomType.Name = dto.Name;
            roomType.Description = dto.Description;

            await _roomTypeRepository.UpdateAsync(roomType);

            await _roomTypeRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(id);

            if (roomType == null)
                throw new Exception("Room Type not found.");

            await _roomTypeRepository.DeleteAsync(roomType);

            await _roomTypeRepository.SaveChangesAsync();
        }
    }
}
