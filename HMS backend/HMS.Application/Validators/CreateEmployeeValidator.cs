using FluentValidation;
using HMS.Application.Dtos.Auth;


namespace HMS.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeedto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\d{11}$");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6);

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Invalid role selected.");
        }
    }
}