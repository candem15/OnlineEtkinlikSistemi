using MediatR;

namespace OES.API.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public string? Id { get; set; }
        public string Password { get; set; }
    }
}
