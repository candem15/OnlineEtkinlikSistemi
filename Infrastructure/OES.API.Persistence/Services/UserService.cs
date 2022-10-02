using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Dtos.User;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<CreateUserResponse> CreateAsync(CreateUser user)
        {
            AppUser createUser = _mapper.Map<AppUser>(user);

            createUser.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(createUser, user.Password);
            if (createUser.WebAddressUrl != null)
                await _userManager.AddToRoleAsync(createUser, "Firma");
            else
                await _userManager.AddToRoleAsync(createUser, "Basit");

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }
    }
}
