using FluentValidation;
using HMS.Application.Dtos.Auth;


namespace HMS.Application.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassworddto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Current Password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New Password is required.")
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword)
                .WithMessage("Passwords do not match.");
        }
    }
}
