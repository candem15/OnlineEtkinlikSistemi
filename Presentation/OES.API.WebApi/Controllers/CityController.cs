using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.DeleteCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Queries.City.GetAllCities;

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

        [HttpPost("create-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> CreateCity(CreateCityCommandRequest createCityCommandRequest)
        {
            CreateCityCommandResponse response = await _mediatR.Send(createCityCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(UpdateCityCommandRequest updateCityCommandRequest)
        {
            UpdateCityCommandResponse response = await _mediatR.Send(updateCityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-city/{id}")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCity([FromRoute]DeleteCityCommandRequest deleteCityCommandRequest)
        {
            DeleteCityCommandResponse response = await _mediatR.Send(deleteCityCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all-cities")]
        public async Task<IActionResult> GetAllCities([FromQuery]GetAllCitiesQueryRequest getAllCitiesQueryRequest)
        {
            GetAllCitiesQueryResponse response = await _mediatR.Send(getAllCitiesQueryRequest);
            return Ok(response);
        }
    }
}
