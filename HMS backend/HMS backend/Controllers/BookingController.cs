using HMS.Application.Dtos.Booking;
using HMS.Application.Interfaces;
using HMS.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // ============================================
        // CUSTOMER
        // ============================================

        [Authorize(Roles = Roles.Customer)]
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingdto dto)
        {
            var customerUserId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _bookingService.CreateBookingAsync(customerUserId, dto);

            return Ok(new
            {
                Message = "Booking request submitted successfully."
            });
        }

        [Authorize(Roles = Roles.Customer)]
        [HttpGet("my-bookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            var customerUserId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _bookingService.GetMyBookingsAsync(customerUserId);

            return Ok(result);
        }

        [Authorize(Roles = Roles.Customer)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound("Booking not found.");

            return Ok(booking);
        }

        // CUSTOMER CHECK-IN
        [Authorize(Roles = Roles.Customer)]
        [HttpPut("checkin/{bookingId}")]
        public async Task<IActionResult> CustomerCheckIn(int bookingId)
        {
            var customerUserId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _bookingService.CustomerCheckInAsync(
                bookingId,
                customerUserId);

            return Ok(new
            {
                Message = "Checked in successfully."
            });
        }

        // CUSTOMER CHECK-OUT
        [Authorize(Roles = Roles.Customer)]
        [HttpPut("checkout/{bookingId}")]
        public async Task<IActionResult> CustomerCheckOut(int bookingId)
        {
            var customerUserId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _bookingService.CustomerCheckOutAsync(
                bookingId,
                customerUserId);

            return Ok(new
            {
                Message = "Checked out successfully."
            });
        }

        // ============================================
        // RECEPTIONIST
        // ============================================

        [Authorize(Roles = Roles.Receptionist)]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingBookings()
        {
            var result = await _bookingService.GetPendingBookingsAsync();

            return Ok(result);
        }

        [Authorize(Roles = Roles.Receptionist)]
        [HttpPut("accept/{id}")]
        public async Task<IActionResult> AcceptBooking(int id)
        {
            var receptionistId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _bookingService.AcceptBookingAsync(id, receptionistId);

            return Ok(new
            {
                Message = "Booking accepted successfully."
            });
        }

        [Authorize(Roles = Roles.Receptionist)]
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectBooking(int id)
        {
            var receptionistId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _bookingService.RejectBookingAsync(id, receptionistId);

            return Ok(new
            {
                Message = "Booking rejected successfully."
            });
        }

        [Authorize(Roles = Roles.Receptionist)]
        [HttpGet("history")]
        public async Task<IActionResult> GetBookingHistory()
        {
            var result = await _bookingService.GetAllBookingsAsync();

            return Ok(result);
        }

        // ============================================
        // OWNER & MANAGER
        // ============================================

        [Authorize(Roles = Roles.Manager + "," + Roles.Owner)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllBookingsAsync();

            return Ok(result);
        }

        [Authorize(Roles = Roles.Owner)]
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetBookingsByStatus(BookingStatus status)
        {
            var bookings = await _bookingService.GetBookingsByStatusAsync(status);

            return Ok(bookings);
        }

        // ============================================
        // OWNER DASHBOARD
        // ============================================

        [Authorize(Roles = Roles.Owner)]
        [HttpGet("accepted")]
        public async Task<IActionResult> GetAcceptedBookings()
        {
            var bookings = await _bookingService.GetAcceptedBookingsAsync();

            return Ok(bookings);
        }

        [Authorize(Roles = Roles.Owner)]
        [HttpGet("rejected")]
        public async Task<IActionResult> GetRejectedBookings()
        {
            var bookings = await _bookingService.GetRejectedBookingsAsync();

            return Ok(bookings);
        }
    }
}