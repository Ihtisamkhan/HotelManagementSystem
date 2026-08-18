using AutoMapper;
using HMS.Application.Dtos.Booking;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;
using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        // Customer creates booking
        public async Task CreateBookingAsync(int customerUserId, CreateBookingdto dto)
        {
            // Check Room
            var room = await _roomRepository.GetByIdAsync(dto.RoomId);

            if (room == null)
                throw new Exception("Room not found.");

            if (room.Status != RoomStatus.Available)
                throw new Exception("Room is not available.");

            // Check Dates
            if (dto.CheckOutDate <= dto.CheckInDate)
                throw new Exception("Check-out date must be after check-in date.");

            // Check overlapping booking
            var roomAlreadyBooked = await _bookingRepository
                .HasOverlappingBookingAsync(
                    dto.RoomId,
                    dto.CheckInDate,
                    dto.CheckOutDate);

            if (roomAlreadyBooked)
                throw new Exception("Room is already booked for the selected dates.");

            // Create Booking
            var booking = new Booking
            {
                CustomerUserId = customerUserId,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                Status = BookingStatus.Pending,
                BookingDate = DateTime.UtcNow
            };

            await _bookingRepository.CreateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        // Customer Bookings
        public async Task<IEnumerable<Bookingdto>> GetMyBookingsAsync(int customerUserId)
        {
            var bookings = await _bookingRepository.GetMyBookingsAsync(customerUserId);

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }

        // Booking Details
        public async Task<Bookingdto?> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                return null;

            return _mapper.Map<Bookingdto>(booking);
        }

        // Receptionist - Pending Bookings
        public async Task<IEnumerable<Bookingdto>> GetPendingBookingsAsync()
        {
            var bookings = await _bookingRepository.GetPendingBookingsAsync();

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }

        // Receptionist - Accept Booking
        public async Task AcceptBookingAsync(int bookingId, int receptionistUserId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                throw new Exception("Booking not found.");

            booking.Status = BookingStatus.Accepted;
            booking.BookingStatusUpdateDate = DateTime.UtcNow;
            booking.AcceptedByUserId = receptionistUserId;

            // Optional:
            // booking.Room.Status = RoomStatus.Booked;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        // Receptionist - Reject Booking
        public async Task RejectBookingAsync(int bookingId, int receptionistUserId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                throw new Exception("Booking not found.");

            booking.Status = BookingStatus.Rejected;
            booking.BookingStatusUpdateDate = DateTime.UtcNow;
            booking.AcceptedByUserId = receptionistUserId;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bookingdto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }

        public async Task CustomerCheckInAsync(int bookingId, int customerUserId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                throw new Exception("Booking not found.");

            if (booking.CustomerUserId != customerUserId)
                throw new Exception("You are not allowed to check in this booking.");

            if (booking.Status != BookingStatus.Accepted)
                throw new Exception("Only accepted bookings can be checked in.");

            var today = DateTime.Today;

            if (today < booking.CheckInDate.Date || today > booking.CheckOutDate.Date)
                throw new Exception("Check-In is only allowed during your booking dates.");

            booking.Status = BookingStatus.CheckedIn;

            booking.ActualCheckInTime = DateTime.Now;

            booking.BookingStatusUpdateDate = DateTime.Now;

            booking.Room.Status = RoomStatus.Occupied;

            await _bookingRepository.UpdateAsync(booking);

            await _bookingRepository.SaveChangesAsync();
        }

        public async Task CustomerCheckOutAsync(int bookingId, int customerUserId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                throw new Exception("Booking not found.");

            if (booking.CustomerUserId != customerUserId)
                throw new Exception("You are not allowed to check out this booking.");

            if (booking.Status != BookingStatus.CheckedIn)
                throw new Exception("You must check in before checking out.");

            booking.Status = BookingStatus.CheckedOut;

            booking.ActualCheckOutTime = DateTime.Now;

            booking.BookingStatusUpdateDate = DateTime.Now;

            booking.Room.Status = RoomStatus.Available;

            await _bookingRepository.UpdateAsync(booking);

            await _bookingRepository.SaveChangesAsync();
        }



        public async Task<IEnumerable<Bookingdto>> GetBookingsByStatusAsync(BookingStatus? status)
        {
            var bookings = await _bookingRepository.GetBookingsByStatusAsync(status);

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }

        public async Task<IEnumerable<Bookingdto>> GetAcceptedBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAcceptedBookingsAsync();

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }

        public async Task<IEnumerable<Bookingdto>> GetRejectedBookingsAsync()
        {
            var bookings = await _bookingRepository.GetRejectedBookingsAsync();

            return _mapper.Map<IEnumerable<Bookingdto>>(bookings);
        }
    }
}
