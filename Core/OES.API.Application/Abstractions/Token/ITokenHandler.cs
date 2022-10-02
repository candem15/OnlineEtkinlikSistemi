using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<Dtos.Token> CreateAccessToken(int dakika, AppUser user);
    }
}
