using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Abstractions.Token;
using OES.API.Application.Dtos;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppUser.LoginUser;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
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
                Token token = await _tokenHandler.CreateAccessToken(10, user);
                return new LoginUserCommandResponse() { Token = token, UserRole = role[0] };
            }

            throw new WrongPasswordException();
        }

    }
}
