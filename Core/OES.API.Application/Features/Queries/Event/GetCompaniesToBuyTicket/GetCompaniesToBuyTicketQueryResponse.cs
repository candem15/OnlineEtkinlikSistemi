using OES.API.Application.Dtos.Event;

namespace OES.API.Application.Features.Queries.Event.GetCompaniesToBuyTicket
{
    public class GetCompaniesToBuyTicketQueryResponse
    {
        public List<GetCompaniesToBuyTicketResponse> Companies { get; set; }
    }
}