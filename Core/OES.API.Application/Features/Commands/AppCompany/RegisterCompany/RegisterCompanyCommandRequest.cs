using MediatR;

namespace OES.API.Application.Features.Commands.AppCompany.RegisterCompany
{
    public class RegisterCompanyCommandRequest : IRequest<RegisterCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string WebsiteDomain { get; set; }
    }
}
