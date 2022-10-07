using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Event.ConfirmEvent
{
    public class ConfirmEventCommandRequest : IRequest<ConfirmEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
