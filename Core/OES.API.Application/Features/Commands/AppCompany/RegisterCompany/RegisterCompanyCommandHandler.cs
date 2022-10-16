using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.AppCompany.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommandRequest, RegisterCompanyCommandResponse>
    {
        private ICompanyService _companyService;

        public RegisterCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<RegisterCompanyCommandResponse> Handle(RegisterCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterCompanyCommandResponse response = await _companyService.RegisterCompanyAsync(request);

            return response;
        }
    }
}
