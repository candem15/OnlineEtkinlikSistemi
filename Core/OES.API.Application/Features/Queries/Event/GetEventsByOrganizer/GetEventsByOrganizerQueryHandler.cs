using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetEventsByOrganizer
{
    public class GetEventsByOrganizerQueryHandler : IRequestHandler<GetEventsByOrganizerQueryRequest, GetEventsByOrganizerQueryResponse>
    {
        private IEventService _eventService;

        public GetEventsByOrganizerQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetEventsByOrganizerQueryResponse> Handle(GetEventsByOrganizerQueryRequest request, CancellationToken cancellationToken)
        {
            GetEventsByOrganizerQueryResponse response = await _eventService.GetEventsByOrganizerAsync(request);
            return response;
        }
    }
}
