namespace OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents
{
    public class GetAllUnconfirmedEventsQueryResponse
    {
        public List<Dtos.Event.UnconfirmedEventsResponse> Events { get; set; }
    }
}