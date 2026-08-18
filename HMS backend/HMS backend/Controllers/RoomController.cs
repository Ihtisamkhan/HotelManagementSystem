using HMS.Application.Dtos.Room;
using HMS.Application.Interfaces;
using HMS.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        
        // PUBLIC / CUSTOMER
        

        // Get All Rooms
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllAsync();

            return Ok(rooms);
        }

        // Get Room By Id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _roomService.GetByIdAsync(id);

            if (room == null)
                return NotFound("Room not found.");

            return Ok(room);
        }

        // Get Available Rooms
        [HttpGet("available")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRoomsAsync();

            return Ok(rooms);
        }

        // Get Rooms By Room Type
        [HttpGet("roomtype/{roomTypeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoomsByType(int roomTypeId)
        {
            var rooms = await _roomService.GetRoomsByTypeAsync(roomTypeId);

            return Ok(rooms);
        }

        
        // MANAGER
        


        // Create Room
        [HttpPost]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomdto dto)
        {
            await _roomService.CreateAsync(dto);

            return Ok(new
            {
                Message = "Room created successfully."
            });
        }
        // Update Room
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IActionResult> UpdateRoom(int id, UpdateRoomdto dto)
        {
            await _roomService.UpdateAsync(id, dto);

            return Ok(new
            {
                Message = "Room updated successfully."
            });
        }

        // Delete Room
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteAsync(id);

            return Ok(new
            {
                Message = "Room deleted successfully."
            });
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetRoomsByStatus(RoomStatus status)
        {
            var rooms = await _roomService.GetRoomsByStatusAsync(status);

            return Ok(rooms);
        }
    }
}
