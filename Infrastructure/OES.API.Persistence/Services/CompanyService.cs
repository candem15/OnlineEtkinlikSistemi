using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Abstractions.Token;
using OES.API.Application.Dtos;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class CompanyService : ICompanyService
    {
        readonly UserManager<AppCompany> _companyManager;
        readonly IValidator<AppCompany> _validator;
        readonly ITokenHandler<AppCompany> _tokenHandler;
        readonly SignInManager<AppCompany> _signInManager;
        readonly IMapper _mapper;

        public CompanyService(UserManager<AppCompany> companyManager, IValidator<AppCompany> validator, IMapper mapper, ITokenHandler<AppCompany> tokenHandler, SignInManager<AppCompany> signInManager)
        {
            _companyManager = companyManager;
            _validator = validator;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }

        public async Task<RegisterCompanyCommandResponse> RegisterCompanyAsync(RegisterCompanyCommandRequest company)
        {
            AppCompany registerCompany = _mapper.Map<AppCompany>(company);
            ValidationResult validationResult = await _validator.ValidateAsync(registerCompany);
            if (!validationResult.IsValid)
                throw new Exception("Hatalı kayıt değerleri girdiniz!");
            registerCompany.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _companyManager.CreateAsync(registerCompany, company.Password);


            if (result.Succeeded)
            {
                return new RegisterCompanyCommandResponse();
            }
            else
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateEmail")
                        throw new Exception("Bu email ile oluşturulmuş hali hazırda bir firma bulunmaktadır.");
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

    }
}
