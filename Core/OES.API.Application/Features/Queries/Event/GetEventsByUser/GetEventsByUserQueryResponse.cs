using OES.API.Application.Dtos.Event;

namespace OES.API.Application.Features.Queries.Event.GetEventsByUser
{
    public class GetEventsByUserQueryResponse
    {
        public List<GetEventsByUserResponse> Events { get; set; }
    }
}