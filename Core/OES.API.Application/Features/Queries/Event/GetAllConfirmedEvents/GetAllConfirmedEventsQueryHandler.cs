using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GetAllConfirmedEventsQueryResponse response = await _eventService.GetAllConfirmedEvents(request);

            return response;
        }
    }
}
