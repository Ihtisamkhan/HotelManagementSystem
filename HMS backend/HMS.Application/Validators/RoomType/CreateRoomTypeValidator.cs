using FluentValidation;
using HMS.Application.Dtos.RoomType;

namespace HMS.Application.Validators.RoomType
{
    public class CreateRoomTypeValidator : AbstractValidator<CreateRoomTypedto>
    {
        public CreateRoomTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

          
        }
    }
}
