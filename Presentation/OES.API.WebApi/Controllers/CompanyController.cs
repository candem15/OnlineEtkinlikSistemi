using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Application.Features.Queries.Event.GetEventsInXml;
using OES.API.Application.Validators;

namespace OES.API.WebApi.Controllers
{
    [EnableCors("CompanyPolicy")]
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
            ValidationResult result = new RegisterCompanyValidator().Validate(registerCompanyCommandRequest);
            if (!result.IsValid)
                return BadRequest(result.Errors);
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
