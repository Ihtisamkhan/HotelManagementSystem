using HMS.Application.Dtos.RoomType;
using HMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // Get All Room Types
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roomTypeService.GetAllAsync();
            return Ok(result);
        }

        // Get Room Type By Id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roomTypeService.GetByIdAsync(id);

            if (result == null)
                return NotFound("Room Type not found.");

            return Ok(result);
        }

        // Create Room Type
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(CreateRoomTypedto dto)
        {
            await _roomTypeService.CreateAsync(dto);

            return Ok(new
            {
                Message = "Room Type created successfully."
            });
        }

        // Update Room Type
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(int id, UpdateRoomTypedto dto)
        {
            await _roomTypeService.UpdateAsync(id, dto);

            return Ok(new
            {
                Message = "Room Type updated successfully."
            });
        }

        // Delete Room Type
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomTypeService.DeleteAsync(id);

            return Ok(new
            {
                Message = "Room Type deleted successfully."
            });
        }
    }
}
