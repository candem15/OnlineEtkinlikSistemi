using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Event.JoinToEvent
{
    public class JoinToEventCommandRequest : IRequest<JoinToEventCommandResponse>
    {
        public string? Id { get; set; }
        public string EventId { get; set; }
    }
}
