using MediatR;

namespace OES.API.Application.Features.Commands.Event.DeleteEvent
{
    public class DeleteEventCommandRequest : IRequest<DeleteEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
