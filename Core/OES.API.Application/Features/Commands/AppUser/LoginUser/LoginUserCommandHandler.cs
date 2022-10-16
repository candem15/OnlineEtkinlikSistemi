using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;
        readonly IMapper _mapper;

        public LoginUserCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request);
            return _mapper.Map<LoginUserCommandResponse>(token);
        }
    }
}
