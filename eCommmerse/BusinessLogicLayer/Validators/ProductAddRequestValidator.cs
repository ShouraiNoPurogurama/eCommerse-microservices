using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators;

public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product Name is required.");
        RuleFor(p => p.Category).IsInEnum().WithMessage("Category is not valid.");
        RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Unit price must be a positive number.");
        RuleFor(p => p.QuantityInStock).GreaterThan(0).WithMessage("Quantity in stock must be a positive number.");
    }
}