using eCommerce.Core.Enums;

namespace eCommerce.Core.DTO;

public record RegisterRequest(
    string? Email,
    string? Password,
    string? PersonName,
    GenderOptions GenderOption
    );