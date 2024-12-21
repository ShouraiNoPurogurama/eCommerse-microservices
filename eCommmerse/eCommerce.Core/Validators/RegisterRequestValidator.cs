using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(r => r.Email).EmailAddress().WithMessage("Email address is invalid.");
        RuleFor(r => r.Password).MinimumLength(6).WithMessage("Password must has at least 6 characters.");
        RuleFor(r => r.GenderOption).IsInEnum().WithMessage("Gender option is invalid.");
    }
}