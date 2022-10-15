using OES.API.Application.Features.Commands.AppCompany.LoginCompany;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Services
{
    public interface ICompanyService
    {
        Task<RegisterCompanyCommandResponse> RegisterCompanyAsync(RegisterCompanyCommandRequest company);
        Task<LoginCompanyCommandResponse> LoginCompanyAsync(LoginCompanyCommandRequest loginDetails);
    }
}
