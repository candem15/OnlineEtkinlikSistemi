using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Dtos.User;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;
using OES.API.Domain.Identity;

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

            CreateUserResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(createUser, "Basit");
                response.Message = "Kullanıcı başarıyla oluşturulmuştur!";
                return response;
            }
            else
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateEmail")
                        response.Message += "Bu email ile oluşturulmuş hali hazırda bir kullanıcı bulunmaktadır. \n";
                    else if (error.Code == "DuplicateUserName")
                        response.Message += "Bu kullanıcı adı ile oluşturulmuş hali hazırda bir kullanıcı bulunmaktadır. \n";
                }
            if (response.Message == null)
                response.Message = "Bilinmeyen bir nedenden ötürü kullanıcı oluşturma işlemi başarısız oldu. \n";

            return response;
        }

        public async Task<GetUserDetailsQueryResponse> GetUserDetailsAsync(GetUserDetailsQueryRequest userDetails)
        {
            AppUser user = await _userManager.FindByIdAsync(userDetails.Id);
            if (user == null)
                throw new NotFoundUserException();
            return new GetUserDetailsQueryResponse()
            {
                Username = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
            };
        }

        public async Task<UpdatePasswordCommandResponse> UpdatePasswordAsync(UpdatePasswordCommandRequest updatePassword)
        {
            var user = await _userManager.FindByIdAsync(updatePassword.Id);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, updatePassword.Password);
            if (result.Succeeded)
                return new UpdatePasswordCommandResponse() { Message = "Şifreniz başarıyla güncellenmiştir", Succeeded = true };
            return new UpdatePasswordCommandResponse() { Message = "Beklenmeyen bir hata oluştu! Şifreniz güncellenemedi.", Succeeded = false };
        }
    }
}
