using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppUser.CreateUser;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
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
    }
}
