using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents
{
    public class GetAllUnconfirmedEventsQueryHandler : IRequestHandler<GetAllUnconfirmedEventsQueryRequest, GetAllUnconfirmedEventsQueryResponse>
    {
        private readonly IEventService _eventService;

        public GetAllUnconfirmedEventsQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<GetAllUnconfirmedEventsQueryResponse> Handle(GetAllUnconfirmedEventsQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllUnconfirmedEventsQueryResponse response = await _eventService.GetAllUnconfirmedEventsAsync(request);

            return response;
        }
    }
}
