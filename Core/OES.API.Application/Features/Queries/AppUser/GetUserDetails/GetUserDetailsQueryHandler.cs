using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Queries.AppUser.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQueryRequest, GetUserDetailsQueryResponse>
    {
        private readonly IUserService _userService;

        public GetUserDetailsQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserDetailsQueryResponse> Handle(GetUserDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            GetUserDetailsQueryResponse response = await _userService.GetUserDetailsAsync(request);

            return response;
        }
    }
}
