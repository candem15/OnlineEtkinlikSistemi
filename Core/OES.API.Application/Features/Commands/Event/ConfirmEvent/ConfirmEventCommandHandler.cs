using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.ConfirmEvent
{
    public class ConfirmEventCommandHandler : IRequestHandler<ConfirmEventCommandRequest, ConfirmEventCommandResponse>
    {
        private readonly IEventService _eventService;

        public ConfirmEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<ConfirmEventCommandResponse> Handle(ConfirmEventCommandRequest request, CancellationToken cancellationToken)
        {
            ConfirmEventCommandResponse response = await _eventService.ConfirmEventAsync(request);

            return response;
        }
    }
}