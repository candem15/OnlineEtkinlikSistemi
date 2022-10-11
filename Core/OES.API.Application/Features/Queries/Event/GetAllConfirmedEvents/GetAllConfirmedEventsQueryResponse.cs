using OES.API.Application.Dtos.Event;

namespace OES.API.Application.Features.Queries.Event.GetAllConfirmedEvents
{
    public class GetAllConfirmedEventsQueryResponse
    {
        public List<ConfirmedEventsResponse> Events { get; set; }
    }
}