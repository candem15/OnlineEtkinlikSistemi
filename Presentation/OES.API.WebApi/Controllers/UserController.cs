using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppUser.CreateUser;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;
using OES.API.Application.Features.Queries.AppUser.GetUserDetails;
using OES.API.Application.Validators;

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
            ValidationResult result = new CreateUserValidator().Validate(createUserCommandRequest);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            CreateUserCommandResponse response = await _mediatR.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Firma,Basit")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            ValidationResult result = new UpdatePasswordValidator().Validate(updatePasswordCommandRequest);
            if (!result.IsValid)
                return BadRequest(result.Errors);
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
