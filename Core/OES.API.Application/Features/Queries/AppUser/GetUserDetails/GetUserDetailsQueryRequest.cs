using MediatR;

namespace OES.API.Application.Features.Queries.AppUser.GetUserDetails
{
    public class GetUserDetailsQueryRequest : IRequest<GetUserDetailsQueryResponse>
    {
        public string? Id { get; set; }
    }
}
