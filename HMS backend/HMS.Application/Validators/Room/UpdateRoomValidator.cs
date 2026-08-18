using FluentValidation;
using HMS.Application.Dtos.Room;

namespace HMS.Application.Validators.Room
{
    public class UpdateRoomValidator : AbstractValidator<UpdateRoomdto>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.RoomNumber)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0);

            RuleFor(x => x.Floor)
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .MaximumLength(500);

        

            RuleFor(x => x.PricePerNight)
    .GreaterThan(0)
    .WithMessage("Price must be greater than zero.");
        }
    }
}
