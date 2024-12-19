using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.API.Validators;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
    }
}