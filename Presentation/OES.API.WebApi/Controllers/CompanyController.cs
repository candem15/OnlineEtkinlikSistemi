using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Application.Features.Queries.Event.GetEventsInXml;

namespace OES.API.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IMediator _mediatR;
        public CompanyController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyCommandRequest registerCompanyCommandRequest)
        {
            RegisterCompanyCommandResponse response = await _mediatR.Send(registerCompanyCommandRequest);

            return AcceptedAtAction(nameof(RegisterCompany));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginCompany(LoginCompanyCommandRequest loginCompanyCommandRequest)
        {
            LoginCompanyCommandResponse response = await _mediatR.Send(loginCompanyCommandRequest);

            return Ok(response);
        }

        [Produces("application/xml")]
        [HttpGet("get-events-in-xml")]
        [Authorize(AuthenticationSchemes = "Default")]
        public async Task<IActionResult> GetEventsInXml([FromQuery] GetEventsForCompaniesQueryRequest getEventsForCompaniesQueryRequest)
        {
            GetEventsForCompaniesQueryResponse response = await _mediatR.Send(getEventsForCompaniesQueryRequest);
            return Ok(response);
        }


        [HttpGet("get-events-in-json")]
        [Authorize(AuthenticationSchemes = "Default")]
        public async Task<IActionResult> GetEventsInJson([FromQuery] GetEventsForCompaniesQueryRequest getEventsForCompaniesQueryRequest)
        {
            GetEventsForCompaniesQueryResponse response = await _mediatR.Send(getEventsForCompaniesQueryRequest);
            return Ok(response);
        }

    }
}
