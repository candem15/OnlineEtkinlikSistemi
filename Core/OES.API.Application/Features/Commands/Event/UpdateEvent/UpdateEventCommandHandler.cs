using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, UpdateEventCommandResponse>
    {
        private readonly IEventService _eventService;

        public UpdateEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateEventCommandResponse response = await _eventService.UpdateAsync(request);

            return response;
        }
    }
}
