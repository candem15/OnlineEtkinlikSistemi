using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetAllConfirmedEvents
{
    public class GetAllConfirmedEventsQueryHandler : IRequestHandler<GetAllConfirmedEventsQueryRequest, GetAllConfirmedEventsQueryResponse>
    {
        private readonly IEventService _eventService;

        public GetAllConfirmedEventsQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetAllConfirmedEventsQueryResponse> Handle(GetAllConfirmedEventsQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllConfirmedEventsQueryResponse response = await _eventService.GetAllConfirmedEventsAsync(request);

            return response;
        }
    }
}
