using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            Application.Dtos.User.CreateUser createUser = _mapper.Map<Application.Dtos.User.CreateUser>(request);
            CreateUserCommandResponse response = _mapper.Map<CreateUserCommandResponse>(await _userService.CreateAsync(createUser));
            return response;
        }
    }
}
