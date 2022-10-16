using MediatR;

namespace OES.API.Application.Features.Commands.Event.ConfirmEvent
{
    public class ConfirmEventCommandRequest : IRequest<ConfirmEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
