using FluentValidation;
using HMS.Application.Dtos.Booking;

namespace HMS.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingdto>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.RoomId)
                .GreaterThan(0);

            RuleFor(x => x.CheckInDate)
                .GreaterThan(DateTime.Today)
                .WithMessage("Check-in date must be in the future.");

            RuleFor(x => x.CheckOutDate)
                .GreaterThan(x => x.CheckInDate)
                .WithMessage("Check-out date must be after check-in date.");
        }
    }
}
