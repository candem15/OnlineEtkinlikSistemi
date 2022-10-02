using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.DeleteCity;
using OES.API.Application.Features.Commands.City.UpdateCity;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        readonly IMediator _mediatR;
        public CityController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("create-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> CreateCity(CreateCityCommandRequest createCityCommandRequest)
        {
            CreateCityCommandResponse response = await _mediatR.Send(createCityCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(UpdateCityCommandRequest updateCityCommandRequest)
        {
            UpdateCityCommandResponse response = await _mediatR.Send(updateCityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCity(DeleteCityCommandRequest deleteCityCommandRequest)
        {
            DeleteCityCommandResponse response = await _mediatR.Send(deleteCityCommandRequest);
            return Ok(response);
        }
    }
}
