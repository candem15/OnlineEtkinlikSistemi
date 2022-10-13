using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppUser.CreateUser;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;
using System.Security.Claims;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediatR;
        public UserController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediatR.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Firma,Basit")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            updatePasswordCommandRequest.Id = User.FindFirst("userId")?.Value;
            UpdatePasswordCommandResponse response = await _mediatR.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-user-details")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit,Admin,Firma")]
        public async Task<IActionResult> GetUserDetails([FromQuery] GetUserDetailsQueryRequest getUserDetailsQueryRequest)
        {
            getUserDetailsQueryRequest.Id = User.FindFirst("userId")?.Value;
            GetUserDetailsQueryResponse response = await _mediatR.Send(getUserDetailsQueryRequest);
            return Ok(response);
        }
    }
}
