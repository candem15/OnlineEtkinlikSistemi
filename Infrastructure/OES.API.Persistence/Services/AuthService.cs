using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Abstractions.Token;
using OES.API.Application.Dtos;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppUser.LoginUser;
using OES.API.Domain.Identity;

namespace OES.API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler<AppUser> _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler<AppUser> tokenHandler, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }
        public async Task<LoginUserCommandResponse> LoginAsync(LoginUserCommandRequest request)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
                throw new WrongUsernameOrEmailException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                Token token = await _tokenHandler.CreateAccessToken(30, user);
                return new LoginUserCommandResponse() { Token = token, UserRole = role[0] };
            }

            throw new WrongPasswordException();
        }

    }
}
