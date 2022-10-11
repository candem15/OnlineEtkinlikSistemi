using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetCompaniesToBuyTicket
{
    public class GetCompaniesToBuyTicketQueryHandler : IRequestHandler<GetCompaniesToBuyTicketQueryRequest, GetCompaniesToBuyTicketQueryResponse>
    {
        private readonly IEventService _eventService;

        public GetCompaniesToBuyTicketQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetCompaniesToBuyTicketQueryResponse> Handle(GetCompaniesToBuyTicketQueryRequest request, CancellationToken cancellationToken)
        {
            GetCompaniesToBuyTicketQueryResponse response = await _eventService.GetCompaniesToBuyTicketAsync(request);

            return response;
        }
    }
}