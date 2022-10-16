using OES.API.Application.Features.Commands.AppUser.LoginUser;

namespace OES.API.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginUserCommandResponse> LoginAsync(LoginUserCommandRequest request);
    }
}
