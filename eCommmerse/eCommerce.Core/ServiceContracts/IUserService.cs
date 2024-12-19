using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Contains use cases for users
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Handle user login use case
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns>An <see cref="AuthenticationResponse"/> object that
    /// contains status of login</returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Handle user register use case
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns>An <see cref="AuthenticationResponse"/> object that contains status of login</returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    
    
}