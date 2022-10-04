﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Dtos.User;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;
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
            {
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
                    else if (error.Code == "InvalidEmail")
                        response.Message += "Geçersiz email bilgisi girdiniz. \n";
                    else if (error.Code == "PasswordTooShort")
                        response.Message += "Şifreniz en az 8 karakterden oluşmalıdır. \n";
                }
            if (response.Message == null)
                 response.Message = "Bilinmeyen bir nedenden ötürü kullanıcı oluşturma işlemi başarısız oldu. \n";

            return response;
        }

        public async Task<GetUserDetailsQueryResponse> GetUserDetailsAsync(GetUserDetailsQueryRequest userDetails)
        {
            AppUser user = await _userManager.FindByEmailAsync(userDetails.Username);
            if (user == null)
                throw new NotFoundUserException();
            return new GetUserDetailsQueryResponse()
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }

        public async Task<UpdatePasswordCommandResponse> UpdatePasswordAsync(UpdatePasswordCommandRequest updatePassword)
        {
            var user = await _userManager.FindByEmailAsync(updatePassword.Id);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, updatePassword.Password);
            if (result.Succeeded)
                return new UpdatePasswordCommandResponse() { Message = "Şifreniz başarıyla güncellenmiştir", Succeeded = true };
            return new UpdatePasswordCommandResponse() { Message = "Beklenmeyen bir hata oluştu! Şifreniz güncellenemedi.", Succeeded = false };
        }
    }
}
