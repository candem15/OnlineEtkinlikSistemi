using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetEventsInXml
{
    public class GetEventsForCompaniesQueryHandler : IRequestHandler<GetEventsForCompaniesQueryRequest, GetEventsForCompaniesQueryResponse>
    {
        private IEventService _eventService;

        public GetEventsForCompaniesQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetEventsForCompaniesQueryResponse> Handle(GetEventsForCompaniesQueryRequest request, CancellationToken cancellationToken)
        {
            GetEventsForCompaniesQueryResponse response = await _eventService.GetEventsInXmlAsync(request);

            return response;
        }
    }
}
