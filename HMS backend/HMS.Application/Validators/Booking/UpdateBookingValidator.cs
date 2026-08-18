using FluentValidation;
using HMS.Application.Dtos.Booking;

namespace HMS.Application.Validators.Booking
{
    public class UpdateBookingValidator : AbstractValidator<UpdateBookingdto>
    {
        public UpdateBookingValidator()
        {
            RuleFor(x => x.CheckInDate)
                .GreaterThan(DateTime.Today);

            RuleFor(x => x.CheckOutDate)
                .GreaterThan(x => x.CheckInDate);
        }
    }
}
