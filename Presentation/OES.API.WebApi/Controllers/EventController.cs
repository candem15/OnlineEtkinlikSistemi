using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Application.Features.Commands.Event.DeleteEvent;
using OES.API.Application.Features.Commands.Event.UpdateEvent;
using OES.API.Application.Features.Queries.Event.GetAllConfirmedEvents;
using OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents;

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
        public async Task<IActionResult> CreateEvent(CreateEventCommandRequest createEventCommandRequest)
        {
            CreateEventCommandResponse response = await _mediatR.Send(createEventCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommandRequest updateEventCommandRequest)
        {
            UpdateEventCommandResponse response = await _mediatR.Send(updateEventCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> DeleteEvent(DeleteEventCommandRequest deleteEventCommandRequest)
        {
            DeleteEventCommandResponse response = await _mediatR.Send(deleteEventCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-unconfirmed-events")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> GetAllUnconfirmedEvents([FromQuery]GetAllUnconfirmedEventsQueryRequest getAllUnconfirmedEventsQueryRequest)
        {
            GetAllUnconfirmedEventsQueryResponse response = await _mediatR.Send(getAllUnconfirmedEventsQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-confirmed-events")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Firma")]
        public async Task<IActionResult> GetAllConfirmedEvents([FromQuery] GetAllConfirmedEventsQueryRequest getAllConfirmedEventsQueryRequest)
        {
            GetAllConfirmedEventsQueryResponse response = await _mediatR.Send(getAllConfirmedEventsQueryRequest);
            return Ok(response);
        }
    }
}
