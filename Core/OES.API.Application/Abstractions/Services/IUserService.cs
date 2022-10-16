using OES.API.Application.Dtos.User;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;

namespace OES.API.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser user);
        Task<UpdatePasswordCommandResponse> UpdatePasswordAsync(UpdatePasswordCommandRequest updatePassword);
        Task<GetUserDetailsQueryResponse> GetUserDetailsAsync(GetUserDetailsQueryRequest userDetails);
    }
}
