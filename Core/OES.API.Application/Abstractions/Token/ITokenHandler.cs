using OES.API.Domain.Identity;

namespace OES.API.Application.Abstractions.Token
{
    public interface ITokenHandler<T> where T : BaseUser
    {
        Task<Dtos.Token> CreateAccessToken(int dakika, T user);
    }
}
