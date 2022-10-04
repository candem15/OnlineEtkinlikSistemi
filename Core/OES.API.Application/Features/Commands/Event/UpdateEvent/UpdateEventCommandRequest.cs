using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public int MaxParticipantsNumber { get; set; }
    }
}
