using AutoMapper;
using HMS.Application.Dtos.Room;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public RoomService(
            IRoomRepository roomRepository,
            IRoomTypeRepository roomTypeRepository,
            IMapper mapper)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        // ===========================
        // Manager
        // ===========================

        public async Task<IEnumerable<Roomdto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Roomdto>>(rooms);
        }

        public async Task<Roomdto?> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
                return null;

            return _mapper.Map<Roomdto>(room);
        }

        public async Task CreateAsync(CreateRoomdto dto)
        {
            // Check duplicate room number
            var roomExists = await _roomRepository.GetByRoomNumberAsync(dto.RoomNumber);

            if (roomExists != null)
                throw new Exception("Room number already exists.");

            // Check Room Type
            Console.WriteLine($"RoomTypeId received: {dto.RoomTypeId}");

            var roomType = await _roomTypeRepository.GetByIdAsync(dto.RoomTypeId);

            Console.WriteLine(roomType == null
                ? "RoomType NOT FOUND"
                : $"RoomType Found: {roomType.Name}");

            if (roomType == null)
            {
                throw new Exception($"Room Type not found. Received Id = {dto.RoomTypeId}");
            }

            var room = _mapper.Map<Room>(dto);

            await _roomRepository.CreateAsync(room);
            await _roomRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateRoomdto dto)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
                throw new Exception("Room not found.");

            var roomType = await _roomTypeRepository.GetByIdAsync(dto.RoomTypeId);

            if (roomType == null)
                throw new Exception("Room Type not found.");

            room.RoomNumber = dto.RoomNumber;
            room.RoomTypeId = dto.RoomTypeId;
            room.PricePerNight = dto.PricePerNight;
            room.Floor = dto.Floor;
            room.Status = dto.Status;
          
            room.Description = dto.Description;

            await _roomRepository.UpdateAsync(room);
            await _roomRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
                throw new Exception("Room not found.");

            await _roomRepository.DeleteAsync(room);
            await _roomRepository.SaveChangesAsync();
        }

        // ===========================
        // Customer / Public Website
        // ===========================

        public async Task<IEnumerable<Roomdto>> GetAvailableRoomsAsync()
        {
            var rooms = await _roomRepository.GetAvailableRoomsAsync();

            return _mapper.Map<IEnumerable<Roomdto>>(rooms);
        }

        public async Task<IEnumerable<Roomdto>> GetRoomsByTypeAsync(int roomTypeId)
        {
            var rooms = await _roomRepository.GetRoomsByTypeAsync(roomTypeId);

            return _mapper.Map<IEnumerable<Roomdto>>(rooms);
        }


        public async Task<IEnumerable<Roomdto>> GetRoomsByStatusAsync(RoomStatus status)
        {
            var rooms = await _roomRepository.GetRoomsByStatusAsync(status);

            return _mapper.Map<IEnumerable<Roomdto>>(rooms);
        }
    }
}