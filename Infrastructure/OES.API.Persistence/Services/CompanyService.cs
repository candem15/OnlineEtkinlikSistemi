using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Abstractions.Token;
using OES.API.Application.Dtos;
using OES.API.Application.Dtos.Event;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Application.Features.Queries.AppCompany.GetCompaniesToBuyTicket;
using OES.API.Domain.Identity;

namespace OES.API.Persistence.Services
{
    public class CompanyService : ICompanyService
    {
        readonly UserManager<AppCompany> _companyManager;
        readonly ITokenHandler<AppCompany> _tokenHandler;
        readonly SignInManager<AppCompany> _signInManager;
        readonly IMapper _mapper;

        public CompanyService(UserManager<AppCompany> companyManager, IMapper mapper, ITokenHandler<AppCompany> tokenHandler, SignInManager<AppCompany> signInManager)
        {
            _companyManager = companyManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }

        public async Task<RegisterCompanyCommandResponse> RegisterCompanyAsync(RegisterCompanyCommandRequest company)
        {
            AppCompany registerCompany = _mapper.Map<AppCompany>(company);
            registerCompany.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _companyManager.CreateAsync(registerCompany, company.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateEmail")
                        throw new DuplicateEmailException();
                }
            }

            return new RegisterCompanyCommandResponse();
        }
        public async Task<LoginCompanyCommandResponse> LoginCompanyAsync(LoginCompanyCommandRequest loginDetails)
        {
            AppCompany company = await _companyManager.FindByNameAsync(loginDetails.UsernameOrEmail);
            if (company == null)
                company = await _companyManager.FindByEmailAsync(loginDetails.UsernameOrEmail);
            if (company == null)
                throw new WrongUsernameOrEmailException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(company, loginDetails.Password, false);

            if (result.Succeeded)
            {
                Token token = await _tokenHandler.CreateAccessToken(30, company);
                return new LoginCompanyCommandResponse() { Token = token };
            }

            throw new WrongPasswordException();
        }


        public async Task<GetCompaniesToBuyTicketQueryResponse> GetCompaniesToBuyTicketAsync(GetCompaniesToBuyTicketQueryRequest request)
        {
            List<GetCompaniesToBuyTicketResponse>? companies = _companyManager?.Users?.Select(x => new GetCompaniesToBuyTicketResponse { CompanyName = x.Name, WebsiteDomain = x.WebsiteDomain }).ToList();

            return new GetCompaniesToBuyTicketQueryResponse() { Companies = companies };
        }
    }
}
