using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(l => l.Email).EmailAddress().WithMessage("Email address is not valid."); 
        RuleFor(l => l.Password).MinimumLength(6).WithMessage("Password must has at least 6 characters."); 
    }
}