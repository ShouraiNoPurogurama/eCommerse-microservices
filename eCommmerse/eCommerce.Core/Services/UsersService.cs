using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using Mapster;

namespace eCommerce.Core.Services;

public class UsersService(IUserRepository userRepository) : IUserService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        var user = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password)
                   ?? throw new AggregateException("User not found");

        return user.Adapt<AuthenticationResponse>() with
        {
            Token = "token",
            Success = true
        };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        var user = registerRequest.Adapt<ApplicationUser>();

        var registeredUser = await userRepository.AddUser(user)
                             ?? throw new UnauthorizedAccessException("User not found");

        return registeredUser.Adapt<AuthenticationResponse>() with
        {
            Token = "token",
            Success = true
        };
    }
}