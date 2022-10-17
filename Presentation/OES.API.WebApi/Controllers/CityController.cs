using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.DeleteCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Queries.City.GetAllCities;
using OES.API.Application.Validators;

namespace OES.API.WebApi.Controllers
{
    [EnableCors("ClientPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CityController : ControllerBase
    {
        readonly IMediator _mediatR;
        public CityController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("create-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> CreateCity(CreateCityCommandRequest createCityCommandRequest)
        {
            ValidationResult result = new CreateCityValidator().Validate(createCityCommandRequest);
            if (!result.IsValid)
                return BadRequest(result);
            CreateCityCommandResponse response = await _mediatR.Send(createCityCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(UpdateCityCommandRequest updateCityCommandRequest)
        {
            ValidationResult result = new UpdateCityValidator().Validate(updateCityCommandRequest);
            if (!result.IsValid)
                return BadRequest(result);
            UpdateCityCommandResponse response = await _mediatR.Send(updateCityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-city/{id}")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCity([FromRoute] DeleteCityCommandRequest deleteCityCommandRequest)
        {
            DeleteCityCommandResponse response = await _mediatR.Send(deleteCityCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all-cities")]
        public async Task<IActionResult> GetAllCities([FromQuery] GetAllCitiesQueryRequest getAllCitiesQueryRequest)
        {
            GetAllCitiesQueryResponse response = await _mediatR.Send(getAllCitiesQueryRequest);
            return Ok(response);
        }
    }
}
