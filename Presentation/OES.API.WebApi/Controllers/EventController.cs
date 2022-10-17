using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Event.ConfirmEvent;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Application.Features.Commands.Event.DeleteEvent;
using OES.API.Application.Features.Commands.Event.JoinToEvent;
using OES.API.Application.Features.Commands.Event.RejectEvent;
using OES.API.Application.Features.Commands.Event.UpdateEvent;
using OES.API.Application.Features.Queries.AppCompany.GetCompaniesToBuyTicket;
using OES.API.Application.Features.Queries.Event.GetAllConfirmedEvents;
using OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents;
using OES.API.Application.Features.Queries.Event.GetEventsByOrganizer;
using OES.API.Application.Features.Queries.Event.GetEventsByUser;
using OES.API.Application.Validators;

namespace OES.API.WebApi.Controllers
{
    [EnableCors("ClientPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
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
            ValidationResult result = new CreateEventValidator().Validate(createEventCommandRequest);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            createEventCommandRequest.Id = User.FindFirst("userId")?.Value;
            CreateEventCommandResponse response = await _mediatR.Send(createEventCommandRequest);
            return Ok(response);
        }

        [HttpPut("update-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommandRequest updateEventCommandRequest)
        {
            ValidationResult result = new UpdateEventValidator().Validate(updateEventCommandRequest);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            UpdateEventCommandResponse response = await _mediatR.Send(updateEventCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-event/{Id}")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit,Admin")]
        public async Task<IActionResult> DeleteEvent([FromRoute] DeleteEventCommandRequest deleteEventCommandRequest)
        {
            DeleteEventCommandResponse response = await _mediatR.Send(deleteEventCommandRequest);
            return Ok(response);
        }

        [HttpPut("confirm-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit,Admin")]
        public async Task<IActionResult> ConfirmEvent(ConfirmEventCommandRequest confirmEventCommandRequest)
        {
            ConfirmEventCommandResponse response = await _mediatR.Send(confirmEventCommandRequest);
            return Ok(response);
        }

        [HttpPut("reject-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit,Admin")]
        public async Task<IActionResult> RejectEvent(RejectEventCommandRequest rejectEventCommandRequest)
        {
            RejectEventCommandResponse response = await _mediatR.Send(rejectEventCommandRequest);
            return Ok(response);
        }

        [HttpPut("join-to-event")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> JoinToEvent([FromBody] JoinToEventCommandRequest joinToEventCommandRequest)
        {
            joinToEventCommandRequest.Id = User.FindFirst("userId")?.Value;
            JoinToEventCommandResponse response = await _mediatR.Send(joinToEventCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-unconfirmed-events")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> GetAllUnconfirmedEvents([FromQuery] GetAllUnconfirmedEventsQueryRequest getAllUnconfirmedEventsQueryRequest)
        {
            GetAllUnconfirmedEventsQueryResponse response = await _mediatR.Send(getAllUnconfirmedEventsQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-confirmed-events")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> GetAllConfirmedEvents([FromQuery] GetAllConfirmedEventsQueryRequest getAllConfirmedEventsQueryRequest)
        {
            GetAllConfirmedEventsQueryResponse response = await _mediatR.Send(getAllConfirmedEventsQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-companies-to-buy-ticket")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> GetCompaniesToBuyTicket([FromQuery] GetCompaniesToBuyTicketQueryRequest companiesToBuyTicketQueryRequest)
        {
            GetCompaniesToBuyTicketQueryResponse response = await _mediatR.Send(companiesToBuyTicketQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-events-by-organizer")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> GetEventsByOrganizer([FromQuery] GetEventsByOrganizerQueryRequest getEventsByOrganizerQueryRequest)
        {
            getEventsByOrganizerQueryRequest.Id = User.FindFirst("userId")?.Value;
            GetEventsByOrganizerQueryResponse response = await _mediatR.Send(getEventsByOrganizerQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-events-by-user")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Basit")]
        public async Task<IActionResult> GetEventsByUser([FromQuery] GetEventsByUserQueryRequest getEventsByOrganizerQueryRequest)
        {
            getEventsByOrganizerQueryRequest.Id = User.FindFirst("userId")?.Value;
            GetEventsByUserQueryResponse response = await _mediatR.Send(getEventsByOrganizerQueryRequest);
            return Ok(response);
        }

    }
}
