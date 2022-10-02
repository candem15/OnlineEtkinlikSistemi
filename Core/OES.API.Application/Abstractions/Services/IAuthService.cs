using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<Dtos.Token> LoginAsync(string usernameOrEmail, string password);
    }
}
