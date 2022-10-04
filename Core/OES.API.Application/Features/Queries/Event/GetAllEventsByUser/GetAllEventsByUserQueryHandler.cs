using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.Event.GetAllEventsByUser
{
    public class GetAllEventsByUserQueryHandler : IRequestHandler<GetAllEventsByUserQueryRequest, GetAllEventsByUserQueryResponse>
    {
        private readonly IEventService _eventService;

        public GetAllEventsByUserQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetAllEventsByUserQueryResponse> Handle(GetAllEventsByUserQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllEventsByUserQueryResponse response = await _eventService.GetAllEventsByUser(request);

            return response;
        }
    }
}