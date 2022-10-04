﻿using Microsoft.AspNetCore.Identity;
using OES.API.Application.Dtos.User;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser user);
        Task<UpdatePasswordCommandResponse> UpdatePasswordAsync(UpdatePasswordCommandRequest updatePassword);
        Task<GetUserDetailsQueryResponse> GetUserDetailsAsync(GetUserDetailsQueryRequest userDetails);
    }
}
