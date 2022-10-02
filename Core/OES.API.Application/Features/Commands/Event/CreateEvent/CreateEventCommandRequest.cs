using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Event.CreateEvent
{
    public class CreateEventCommandRequest : IRequest<CreateEventCommandResponse>
    {
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public string CategoryId { get; set; }
        public string CityId { get; set; }
        public int MaxParticipantsNumber { get; set; }
        public double? TicketPrice { get; set; }
    }
}
