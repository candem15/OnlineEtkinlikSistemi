using MediatR;
using OES.API.Application.Abstractions.Services;

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
