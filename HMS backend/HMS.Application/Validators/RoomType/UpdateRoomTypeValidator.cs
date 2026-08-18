using FluentValidation;
using HMS.Application.Dtos.RoomType;

namespace HMS.Application.Validators.RoomType
{
    public class UpdateRoomTypeValidator : AbstractValidator<UpdateRoomTypedto>
    {
        public UpdateRoomTypeValidator()
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