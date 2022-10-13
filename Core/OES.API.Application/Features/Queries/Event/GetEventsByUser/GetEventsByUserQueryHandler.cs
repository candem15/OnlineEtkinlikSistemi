using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetEventsByUser
{
    public class GetEventsByUserQueryHandler : IRequestHandler<GetEventsByUserQueryRequest, GetEventsByUserQueryResponse>
    {
        private IEventService _eventService;

        public GetEventsByUserQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetEventsByUserQueryResponse> Handle(GetEventsByUserQueryRequest request, CancellationToken cancellationToken)
        {
            GetEventsByUserQueryResponse response = await _eventService.GetEventsByUserAsync(request);

            return response;
        }
    }
}