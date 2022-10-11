using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.JoinToEvent
{
    public class JoinToEventCommandHandler : IRequestHandler<JoinToEventCommandRequest, JoinToEventCommandResponse>
    {
        private readonly IEventService _eventService;

        public JoinToEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<JoinToEventCommandResponse> Handle(JoinToEventCommandRequest request, CancellationToken cancellationToken)
        {
            JoinToEventCommandResponse response = await _eventService.JoinToEventAsync(request);

            return response;
        }
    }
}