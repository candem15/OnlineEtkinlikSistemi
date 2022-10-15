using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Token
{
    public interface ITokenHandler<T> where T : BaseUser
    {
        Task<Dtos.Token> CreateAccessToken(int dakika, T user);
    }
}
