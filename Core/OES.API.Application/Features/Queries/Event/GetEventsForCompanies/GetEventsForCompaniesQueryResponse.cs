using OES.API.Application.Dtos.Event;

namespace OES.API.Application.Features.Queries.Event.GetEventsInXml
{
    public class GetEventsForCompaniesQueryResponse
    {
        public List<GetEventsForCompaniesResponse> Events { get; set; }
    }
}