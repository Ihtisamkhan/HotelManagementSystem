using FluentValidation;
using HMS.Application.Dtos.Booking;

namespace HMS.Application.Validators.Booking
{
    public class RejectBookingValidator : AbstractValidator<RejectBookingdto>
    {
        public RejectBookingValidator()
        {
            RuleFor(x => x.Reason)
                .MaximumLength(500);
        }
    }
}