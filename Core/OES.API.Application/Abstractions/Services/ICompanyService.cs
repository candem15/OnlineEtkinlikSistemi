using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Application.Features.Queries.AppCompany.GetCompaniesToBuyTicket;

namespace OES.API.Application.Abstractions.Services
{
    public interface ICompanyService
    {
        Task<RegisterCompanyCommandResponse> RegisterCompanyAsync(RegisterCompanyCommandRequest company);
        Task<LoginCompanyCommandResponse> LoginCompanyAsync(LoginCompanyCommandRequest loginDetails);
        Task<GetCompaniesToBuyTicketQueryResponse> GetCompaniesToBuyTicketAsync(GetCompaniesToBuyTicketQueryRequest request);

    }
}
