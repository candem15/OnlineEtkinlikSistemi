using OES.API.Application.Dtos.Event;

namespace OES.API.Application.Features.Queries.Event.GetEventsByOrganizer
{
    public class GetEventsByOrganizerQueryResponse
    {
        public List<GetEventsByOrganizerResponse> Events { get; set; }
    }
}
