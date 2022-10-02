using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Event.CreateEvent;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public EventController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("create-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> CreateEvent(CreateEventCommandRequest creatEventCommandRequest)
        {
            CreateEventCommandResponse response = await _mediatR.Send(creatEventCommandRequest);
            return Ok(response);
        }
    }
}
