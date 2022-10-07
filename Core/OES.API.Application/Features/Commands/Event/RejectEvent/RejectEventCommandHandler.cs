using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.RejectEvent
{
    public class RejectEventCommandHandler : IRequestHandler<RejectEventCommandRequest, RejectEventCommandResponse>
    {
        private readonly IEventService _eventService;

        public RejectEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<RejectEventCommandResponse> Handle(RejectEventCommandRequest request, CancellationToken cancellationToken)
        {
            RejectEventCommandResponse response = await _eventService.RejectEventAsync(request);

            return response;
        }
    }
}