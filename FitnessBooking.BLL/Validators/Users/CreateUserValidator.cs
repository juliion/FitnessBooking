using System.Text.RegularExpressions;
using FitnessBooking.BLL.DTOs.Users.Requests;
using FluentValidation;

namespace FitnessBooking.BLL.Validators.Users;

public class CreateUserValidator : AbstractValidator<CreateUserDTO>
{
    public CreateUserValidator()
    {
        RuleFor(ci => ci.Username)
            .NotNull()
            .NotEmpty();
        RuleFor(ci => ci.Email)
            .NotNull()
            .EmailAddress();
        RuleFor(ci => ci.Password)
            .NotNull()
            .NotEmpty()
            .Length(5, 15)
            .Must(IsValidPassword);
    }
    
    private bool IsValidPassword(string password)
    {
        var lowercase = new Regex("[a-z]+");
        var uppercase = new Regex("[A-Z]+");
        var digit = new Regex("(\\d)+");
        var symbol = new Regex("(\\W)+");

        return lowercase.IsMatch(password)
               && uppercase.IsMatch(password)
               && digit.IsMatch(password)
               && symbol.IsMatch(password);
    }
}