using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
    {
        private readonly IEventService _eventService;

        public DeleteEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteEventCommandResponse response = await _eventService.DeleteAsync(request);

            return response;
        }
    }
}
