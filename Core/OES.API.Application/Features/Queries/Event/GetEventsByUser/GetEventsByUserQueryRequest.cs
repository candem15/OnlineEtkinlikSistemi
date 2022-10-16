using MediatR;

namespace OES.API.Application.Features.Queries.Event.GetEventsByUser
{
    public class GetEventsByUserQueryRequest : IRequest<GetEventsByUserQueryResponse>
    {
        public string? Id { get; set; }
    }
}
