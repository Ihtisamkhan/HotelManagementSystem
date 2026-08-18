using FluentValidation;
using HMS.Application.Dtos.Auth;


namespace HMS.Application.Validators
{
    public class LoginValidator : AbstractValidator<Logindto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6);
        }
    }
}