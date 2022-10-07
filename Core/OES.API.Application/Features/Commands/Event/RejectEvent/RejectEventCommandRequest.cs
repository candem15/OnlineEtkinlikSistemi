using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Event.RejectEvent
{
    public class RejectEventCommandRequest : IRequest<RejectEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
