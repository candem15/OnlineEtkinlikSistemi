using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.AppCompany.LoginCompany
{
    public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommandRequest, LoginCompanyCommandResponse>
    {
        private ICompanyService _companyService;

        public LoginCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<LoginCompanyCommandResponse> Handle(LoginCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            LoginCompanyCommandResponse response = await _companyService.LoginCompanyAsync(request);

            return response;
        }
    }
}
