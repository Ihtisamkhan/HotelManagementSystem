using AutoMapper;
using HMS.Application.Dtos.Auth;
using HMS.Application.Dtos.Booking;
using HMS.Application.Dtos.Profile;
using HMS.Application.Dtos.Room;
using HMS.Application.Dtos.RoomType;
using HMS.Application.Dtos.StaffTask;
using HMS.Domain.Entities;
using HMS.Domain.Enums;

namespace HMS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Register Owner
            CreateMap<RegisterOwnerdto, ApplicationUser>();

            // Register Customer
            CreateMap<RegisterCustomerdto, ApplicationUser>();

            // Profile 
            CreateMap<ApplicationUser, ProfileDto>();

            // Create Employee
            CreateMap<CreateEmployeedto, ApplicationUser>();

            // Update Employee
            CreateMap<UpdateEmployeedto, ApplicationUser>();

            // Login Response
            CreateMap<ApplicationUser, LoginResponsedto>();

            // Room Type
            CreateMap<CreateRoomTypedto, RoomType>();

            CreateMap<UpdateRoomTypedto, RoomType>();

            CreateMap<RoomType, RoomTypedto>();

            // Room
            CreateMap<CreateRoomdto, Room>();

            

            CreateMap<UpdateRoomdto, Room>();

            CreateMap<Room, Roomdto>()
     .ForMember(dest => dest.RoomTypeName,
         opt => opt.MapFrom(src => src.RoomType.Name))
     .ForMember(dest => dest.CustomerName,
         opt => opt.MapFrom(src =>
             src.Bookings
                 .Where(b => b.Status == BookingStatus.Accepted || b.Status == BookingStatus.CheckedIn)
                 .OrderByDescending(b => b.BookingDate)
                 .Select(b => b.Customer.FullName)
                 .FirstOrDefault()));
            CreateMap<ApplicationUser, ProfileDto>();

            CreateMap<UpdateProfileDto, ApplicationUser>();

            // Booking
            CreateMap<Booking, Bookingdto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FullName))

                .ForMember(dest => dest.RoomNumber,
                    opt => opt.MapFrom(src => src.Room.RoomNumber))

                .ForMember(dest => dest.ActualCheckInTime,
                    opt => opt.MapFrom(src => src.ActualCheckInTime))

                .ForMember(dest => dest.ActualCheckOutTime,
                    opt => opt.MapFrom(src => src.ActualCheckOutTime));
            // Staff Task
            CreateMap<CreateTaskDto, StaffTask>();

            CreateMap<UpdateTaskDto, StaffTask>();

            CreateMap<StaffTask, StaffTaskDto>()
                .ForMember(dest => dest.StaffName,
                    opt => opt.MapFrom(src => src.Staff.FullName))
                .ForMember(dest => dest.RoomNumber,
                    opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomNumber : ""))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}