using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppUser.LoginUser;

namespace OES.API.WebApi.Controllers
{
    [EnableCors("ClientPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediatR;
        public AuthController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediatR.Send(loginUserCommandRequest);
            return Ok(response);
        }

    }
}
