using MediatR;

namespace OES.API.Application.Features.Commands.Event.RejectEvent
{
    public class RejectEventCommandRequest : IRequest<RejectEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
