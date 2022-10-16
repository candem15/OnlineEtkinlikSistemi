using MediatR;

namespace OES.API.Application.Features.Commands.Event.JoinToEvent
{
    public class JoinToEventCommandRequest : IRequest<JoinToEventCommandResponse>
    {
        public string? Id { get; set; }
        public string EventId { get; set; }
    }
}
