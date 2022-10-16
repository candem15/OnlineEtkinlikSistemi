using MediatR;

namespace OES.API.Application.Features.Commands.AppCompany.LoginCompany
{
    public class LoginCompanyCommandRequest : IRequest<LoginCompanyCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
