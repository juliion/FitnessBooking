using FitnessBooking.BLL.DTOs.Users.Requests;
using FluentValidation;

namespace FitnessBooking.BLL.Validators.Users;

public class LoginUserValidator : AbstractValidator<LoginUserDTO>
{
    public LoginUserValidator()
    {
        RuleFor(ci => ci.Email)
            .NotNull()
            .EmailAddress();
        RuleFor(ci => ci.Password)
            .NotNull()
            .NotEmpty()
            .Length(5, 15);
    }
}